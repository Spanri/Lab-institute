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
char result1[80]; // для идентификатора
char result2[80]; // для дескриптора
// события
HANDLE event;
// для закрытия createMyProcess только после закрытия потока
bool k = false;

void Thread(void* pParams)
{
	while (true)
	{
		// ждем соединения
		sock = accept(listener, (sockaddr *)&addr, &socket_name_size);

		//ждем, пока клиент увидит, что подключился к нам
		WaitForSingleObject(event, INFINITE);
		MessageBox(0, L"К серверу подключился клиент\n", 0, MB_OK);

		char result1[80];
		char result2[80];
		LPTSTR s;

		// текущий процесс
		DWORD id = GetCurrentProcessId();
		strcpy(result1, "");
		itoa(UINT(id), result1, 10);

		// псевдодескриптор
		HANDLE ps = GetCurrentProcess();
		// дескриптор с OpenProcess
		HANDLE buf2 = OpenProcess(PROCESS_ALL_ACCESS, FALSE, id);
		strcpy(result2, "");
		itoa(UINT(buf2), result2, 10);

		// отправляем сообщения
		send(sock, result1, sizeof(result1) - 1, 0);
		send(sock, result2, sizeof(result2) - 1, 0);

		// закрываем handle
		if (!CloseHandle(buf2))
			MessageBox(0, L"Ошибка закрытия Handle\n", 0, MB_OK);
	}
	_endthread();
}

void createMyProcess()
{
	// события
	event = CreateEvent(NULL, TRUE, FALSE, L"Serv2");

	// версия сокета
	WORD wVersionRequested = MAKEWORD(1, 1);
	// инициализация сокета
	if (WSAStartup(wVersionRequested, &wsaData))
	{
		MessageBox(0, L"Не иницилизирован сокет! \n" + int(WSAGetLastError), 0, MB_OK);
		WSACleanup();
	}

	// создание сокета
	listener = socket(AF_INET, SOCK_STREAM, NULL);

	// заполняем структуру сокета
	ZeroMemory(&addr, sizeof(addr));
	addr.sin_family = AF_INET;
	addr.sin_port = htons(1234);
	addr.sin_addr.s_addr = htonl(INADDR_ANY);	// сервер принимает подключения на все ip-адреса
	socket_name_size = sizeof(addr);

	//делаем привязку
	if (bind(listener, (struct sockaddr *)&addr, socket_name_size)<0)
	{
		MessageBox(0, L"Сокет не binding\n", 0, MB_OK);
		exit(1);
	}
	MessageBox(0, L"Сокет bind\n", 0, MB_OK);

	// максимум входящих соединений - 1
	listen(listener, 1);
	MessageBox(0, L"Установлено прослушивание\n", 0, MB_OK);

	// создаем поток в функции Thread
	_beginthread(Thread, 0, NULL);
	while (true) {
		if (k == true) break;
	}
}