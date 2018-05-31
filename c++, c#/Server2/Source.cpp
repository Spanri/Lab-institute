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
// listener �����������, sock ��� ���������� (�����)
SOCKET sock, listener;
// ��� ������
int socket_name_size;
char buff[1024];
struct sockaddr_in addr;
WSADATA wsaData;
// ��� �����������
char result1[80]; // ��� ��������������
char result2[80]; // ��� �����������
// �������
HANDLE event;
// ��� �������� createMyProcess ������ ����� �������� ������
bool k = false;

void Thread(void* pParams)
{
	while (true)
	{
		// ���� ����������
		sock = accept(listener, (sockaddr *)&addr, &socket_name_size);

		//����, ���� ������ ������, ��� ����������� � ���
		WaitForSingleObject(event, INFINITE);
		MessageBox(0, L"� ������� ����������� ������\n", 0, MB_OK);

		char result1[80];
		char result2[80];
		LPTSTR s;

		// ������� �������
		DWORD id = GetCurrentProcessId();
		strcpy(result1, "");
		itoa(UINT(id), result1, 10);

		// ����������������
		HANDLE ps = GetCurrentProcess();
		// ���������� � OpenProcess
		HANDLE buf2 = OpenProcess(PROCESS_ALL_ACCESS, FALSE, id);
		strcpy(result2, "");
		itoa(UINT(buf2), result2, 10);

		// ���������� ���������
		send(sock, result1, sizeof(result1) - 1, 0);
		send(sock, result2, sizeof(result2) - 1, 0);

		// ��������� handle
		if (!CloseHandle(buf2))
			MessageBox(0, L"������ �������� Handle\n", 0, MB_OK);
	}
	_endthread();
}

void createMyProcess()
{
	// �������
	event = CreateEvent(NULL, TRUE, FALSE, L"Serv2");

	// ������ ������
	WORD wVersionRequested = MAKEWORD(1, 1);
	// ������������� ������
	if (WSAStartup(wVersionRequested, &wsaData))
	{
		MessageBox(0, L"�� �������������� �����! \n" + int(WSAGetLastError), 0, MB_OK);
		WSACleanup();
	}

	// �������� ������
	listener = socket(AF_INET, SOCK_STREAM, NULL);

	// ��������� ��������� ������
	ZeroMemory(&addr, sizeof(addr));
	addr.sin_family = AF_INET;
	addr.sin_port = htons(1234);
	addr.sin_addr.s_addr = htonl(INADDR_ANY);	// ������ ��������� ����������� �� ��� ip-������
	socket_name_size = sizeof(addr);

	//������ ��������
	if (bind(listener, (struct sockaddr *)&addr, socket_name_size)<0)
	{
		MessageBox(0, L"����� �� binding\n", 0, MB_OK);
		exit(1);
	}
	MessageBox(0, L"����� bind\n", 0, MB_OK);

	// �������� �������� ���������� - 1
	listen(listener, 1);
	MessageBox(0, L"����������� �������������\n", 0, MB_OK);

	// ������� ����� � ������� Thread
	_beginthread(Thread, 0, NULL);
	while (true) {
		if (k == true) break;
	}
}