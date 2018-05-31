#include "stdafx.h"
#include <windows.h>
#include <winsock2.h>
#include <string.h>
#include <ws2tcpip.h>
#include <stdio.h>
#include <locale.h> 
#include <process.h>

// Need to link with Ws2_32.lib
#pragma comment(lib, "ws2_32.lib")

char result[80];
// listener изначальный, sock для соединения (новый)
SOCKET sock, listener;
// для сокета
int socket_name_size;
char buff[1024];
struct sockaddr_in addr;
WSADATA wsaData;
// для результатов
char result1[80]; // для цвета 1
char result2[80]; // для цвета 2
char result3[80]; // для языка клавиатуры
// события
HANDLE event;
// для закрытия createMyProcess только после закрытия потока
bool k = false;

HWND wnd;

/// <summary>
/// Преобразует цвет в строку из rgb составляющих
/// </summary>
void COLORREF2string(COLORREF cr, char* buffer) {
	*buffer = '(';
	buffer += 1;

	itoa(GetRValue(cr), buffer, 10);
	buffer += strlen(buffer);
	*buffer = ',';
	buffer += 1;
	*buffer = ' ';
	buffer += 1;

	itoa(GetBValue(cr), buffer, 10);
	buffer += strlen(buffer);
	*buffer = ',';
	buffer += 1;
	*buffer = ' ';
	buffer += 1;

	itoa(GetGValue(cr), buffer, 10);
	buffer += strlen(buffer);
	*buffer = ')';
	buffer += 1;
}

/// <summary>
/// Поток
/// </summary>
void Thread(void* pParams)
{
	while (true)
	{
		// ждем соединения
		sock = accept(listener, (sockaddr *)&addr, &socket_name_size);

		//ждем, пока клиент увидит, что подключился к нам (события)
		WaitForSingleObject(event, INFINITE);
		MessageBox(0, L"К серверу подключился клиент", L"Клиент", MB_OK);

		// получаем 2 системных цвета //
		COLORREF color[] = { GetSysColor(COLOR_MENUTEXT), GetSysColor(COLOR_MENU) };

		strcpy(result1, "");
		COLORREF2string(color[0], result1);

		strcpy(result2, "");
		COLORREF2string(color[1], result2);

		// код клавиатуры
		TCHAR lang[] = _T("OTHER");
		switch (LOWORD(GetKeyboardLayout(GetWindowThreadProcessId(wnd, NULL)))) {
		case 1033:
			strcpy(result3, "EN");
			break;
		case 1049:
			strcpy(result3, "RU");
			break;
		default:
			strcpy(result3, "неизвестный");
		}

		// отправляем сообщения
		send(sock, result1, sizeof(result1) - 1, 0);
		send(sock, result2, sizeof(result2) - 1, 0);
		send(sock, result3, sizeof(result3) - 1, 0);
	}

	k = true;
	_endthread();
}

/// <summary>
/// Основная функция для создания сокета и передачи
/// управления потоку
/// </summary>
void createMyProcess(HWND hWnd)
{
	wnd = hWnd;
	// события
	event = CreateEvent(NULL, TRUE, FALSE, L"Serv1");

	// версия сокета
	WORD wVersionRequested = MAKEWORD(1, 1);
	// инициализация сокета
	if (WSAStartup(wVersionRequested, &wsaData))
	{
		MessageBox(0, L"Не иницилизирован сокет!" + int(WSAGetLastError), 0, MB_OK);
		WSACleanup();
	}

	// создание сокета
	listener = socket(AF_INET, SOCK_STREAM, NULL);

	// заполняем структуру сокета
	ZeroMemory(&addr, sizeof(addr));
	addr.sin_family = AF_INET;
	addr.sin_port = htons(3000);
	addr.sin_addr.s_addr = htonl(INADDR_ANY);	// сервер принимает подключения на все ip-адреса
	socket_name_size = sizeof(addr);

	//делаем привязку
	if (bind(listener, (struct sockaddr *)&addr, socket_name_size)<0)
	{
		MessageBox(0, L"Сокет не binding", 0, MB_OK);
		exit(1);
	}

	// максимум входящих соединений - 1
	listen(listener, 1);
	MessageBox(0, L"Установлено прослушивание", L"Соединение", MB_OK);

	// создаем поток в функции Thread
	HANDLE tr = HANDLE(_beginthread(Thread, 0, NULL));
	//WaitForSingleObject(tr, 0);
	while (true) {
		if (k == true) break;
	}
}