#include "stdafx.h"
#include <windows.h>
#include <winsock2.h>
#include <string.h>
#include <ws2tcpip.h>
#include <stdio.h>
#include <locale.h>  

// Need to link with Ws2_32.lib
#pragma comment(lib, "ws2_32.lib")

typedef u_int SOCKET;
SOCKET servsocket;
SOCKADDR_IN serv_addr;

int error;

// Инициализация сокета
void StartSocket()
{
	WSADATA wsaData;
	WORD wVersionRequested = MAKEWORD(1, 1);	// версия сокетов

	if (WSAStartup(wVersionRequested, &wsaData))
	{
		error = WSAGetLastError();
		MessageBox(0, L"Ошибка инициализации сокета\n", 0, MB_OK);
		WSACleanup();
	}
}

// создание сокета, к которому будем подключаться
int CreateSocket(int port)
{
	char HostName[1024];
	hostent* hn;
	LPHOSTENT lphost;

	/// создаем сокет ///
	
	servsocket = socket(AF_INET, SOCK_STREAM, 0);
	if (servsocket == INVALID_SOCKET)
	{
		MessageBox(0, L"Ошибка создания сокета\n", 0, MB_OK);
		return 2;
	}

	/// заполняем структуру сокета ///

	ZeroMemory(&serv_addr, sizeof(serv_addr));
	// тип адреса (TCP/IP)
	serv_addr.sin_family = AF_INET;
	// получаем hostname по порту 3000 (куда будем подключаться)
	gethostname(HostName, port);
	lphost = gethostbyname(HostName);
	// забиваем имя ip-адреса полученного в структуру
	serv_addr.sin_addr.S_un.S_addr = *(DWORD*) lphost->h_addr_list[0];
	// порт, к которому подключаемся
	serv_addr.sin_port = htons(port);

	/// подключаемся к сокету ///

	if (SOCKET_ERROR == (connect(servsocket, (sockaddr *)&serv_addr, sizeof(serv_addr))))
	{
		error = WSAGetLastError();
		MessageBox(0, L"Ошибка соединения", 0, MB_OK);
		return 2;
	}
	MessageBox(0, L"Соединение установлено\n", L"Соединение", MB_OK);
}

// рисование текста в окне
void Draw(HDC hdc, char* szText, int left, int top, int right, int bottom) 
{
	LOGFONTW lfFont;
	HFONT hFontOld = NULL;
	static HFONT hFont = NULL;
	wchar_t wtext[50];
	LPWSTR ptr;
	_locale_t locale;
	DWORD clrText;

	// прямоугольник, в пределах которого находится текст
	RECT rect = { left, top, right, bottom };

	ZeroMemory(&lfFont, sizeof(lfFont));
	// размер и шрифт
	lfFont.lfHeight = 18;
	lfFont.lfWeight = FW_NORMAL;
	hFont = CreateFontIndirectW(&lfFont);
	if (hFont != NULL) hFontOld = static_cast<HFONT>(SelectObject(hdc, hFont));
	// цвет текста
	clrText = SetTextColor(hdc, RGB(0, 0, 0));

	locale = _create_locale(LC_ALL, "RU");
	_mbstowcs_l(wtext, szText, strlen(szText) + 1, locale); //Plus null
	ptr = wtext;
	DrawText(hdc, ptr, -1, &rect, DT_EXTERNALLEADING | DT_NOPREFIX | DT_WORDBREAK | DT_CENTER | DT_SINGLELINE | DT_VCENTER);

	SetTextColor(hdc, clrText);
	if (hFont != NULL) 
	{
		SelectObject(hdc, hFontOld);
	}
}

// опрос 1ого сервера
void opros1(HWND hWnd) {
	char buff[80];
	int actual_len = 0;
	char result[80];
	HANDLE event1;

	// рисование
	PAINTSTRUCT ps;
	HDC hdc = BeginPaint(hWnd, &ps);

	shutdown(servsocket, 2);
	WSACleanup();
	InvalidateRect(hWnd, 0, TRUE);
	UpdateWindow(hWnd);

	event1 = CreateEvent(NULL, TRUE, FALSE, L"Serv1");
	StartSocket();
	if (CreateSocket(3000) == 2) return;

	MessageBox(0, L"Подключились к серверу 1", L"Сервер 1", 0);

	// событие первого сервера
	SetEvent(event1);
	
	if (SOCKET_ERROR == (actual_len = recv(servsocket, buff, sizeof(buff) - 1, 0)))
	{
		error = WSAGetLastError();
		MessageBox(0, L"recv error ", 0, MB_OK);
		exit(1);
	}

	Rectangle(hdc, 98, 98, 452, 402);
	Rectangle(hdc, 598, 98, 1002, 402);

	/// первый запрос ///

	strcpy(result, "Цвет COLOR_MENUTEXT: ");
	strcat(result, buff);
	Draw(hdc, result, 100, 100, 450, 300);

	if (SOCKET_ERROR == (actual_len = recv(servsocket, buff, sizeof(buff) - 1, 0)))
	{
		error = WSAGetLastError();
		MessageBox(0, L"recv error ", 0, MB_OK);
		exit(1);
	}
	strcpy(result, "Цвет COLOR_MENU: ");
	strcat(result, buff);
	Draw(hdc, result, 100, 200, 450, 400);

	/// второй запрос ///

	if (SOCKET_ERROR == (actual_len = recv(servsocket, buff, sizeof(buff) - 1, 0)))
	{
		error = WSAGetLastError();
		MessageBox(0, L"recv error ", 0, MB_OK);
		exit(1);
	}
	strcpy(result, "Язык: ");
	strcat(result, buff);
	Draw(hdc, result, 600, 100, 1000, 500);

	// освобождаем событие первого сервера и заканчиваем рисование
	ResetEvent(event1);
	EndPaint(hWnd, &ps);
}

// опрос 2ого сервера
void opros2(HWND hWnd) {
	char buff[80];
	int actual_len = 0;
	char result[80];
	HANDLE event2;

	// рисование
	PAINTSTRUCT ps;
	HDC hdc = BeginPaint(hWnd, &ps);

	shutdown(servsocket, 2);
	WSACleanup();
	InvalidateRect(hWnd, 0, TRUE);
	UpdateWindow(hWnd);

	event2 = CreateEvent(NULL, TRUE, FALSE, L"Serv2");
	StartSocket();
	if (CreateSocket(1234) == 2) return;
	
	MessageBox(0, L"Подключились к серверу 2", L"Сервер 2", 0);

	SetEvent(event2);
	
	/// первый запрос ///

	if (SOCKET_ERROR == (actual_len = recv(servsocket, buff, sizeof(buff) - 1, 0)))
	{
		error = WSAGetLastError();
		MessageBox(0, L"recv error ", 0, MB_OK);
		exit(1);
	}

	Rectangle(hdc, 98, 98, 502, 502);
	Rectangle(hdc, 598, 98, 1002, 502);

	strcpy(result, "Идентификатор текущего процесса: ");
	strcat(result, buff);
	Draw(hdc, result, 100, 100, 500, 500);

	/// второй запрос ///

	if (SOCKET_ERROR == (actual_len = recv(servsocket, buff, sizeof(buff) - 1, 0)))
	{
		error = WSAGetLastError();
		MessageBox(0, L"recv error ", 0, MB_OK);
		exit(1);
	}
	strcpy(result, "Дескриптор текущего процесса: ");
	strcat(result, buff);
	Draw(hdc, result, 600, 100, 1000, 500);

	// освобождаем событие первого сервера и заканчиваем рисование
	ResetEvent(event2);
	EndPaint(hWnd, &ps);
}