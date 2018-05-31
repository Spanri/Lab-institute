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
char result1[80]; // ��� ����� 1
char result2[80]; // ��� ����� 2
char result3[80]; // ��� ����� ����������
// �������
HANDLE event;
// ��� �������� createMyProcess ������ ����� �������� ������
bool k = false;

HWND wnd;

/// <summary>
/// ����������� ���� � ������ �� rgb ������������
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
/// �����
/// </summary>
void Thread(void* pParams)
{
	while (true)
	{
		// ���� ����������
		sock = accept(listener, (sockaddr *)&addr, &socket_name_size);

		//����, ���� ������ ������, ��� ����������� � ��� (�������)
		WaitForSingleObject(event, INFINITE);
		MessageBox(0, L"� ������� ����������� ������", L"������", MB_OK);

		// �������� 2 ��������� ����� //
		COLORREF color[] = { GetSysColor(COLOR_MENUTEXT), GetSysColor(COLOR_MENU) };

		strcpy(result1, "");
		COLORREF2string(color[0], result1);

		strcpy(result2, "");
		COLORREF2string(color[1], result2);

		// ��� ����������
		TCHAR lang[] = _T("OTHER");
		switch (LOWORD(GetKeyboardLayout(GetWindowThreadProcessId(wnd, NULL)))) {
		case 1033:
			strcpy(result3, "EN");
			break;
		case 1049:
			strcpy(result3, "RU");
			break;
		default:
			strcpy(result3, "�����������");
		}

		// ���������� ���������
		send(sock, result1, sizeof(result1) - 1, 0);
		send(sock, result2, sizeof(result2) - 1, 0);
		send(sock, result3, sizeof(result3) - 1, 0);
	}

	k = true;
	_endthread();
}

/// <summary>
/// �������� ������� ��� �������� ������ � ��������
/// ���������� ������
/// </summary>
void createMyProcess(HWND hWnd)
{
	wnd = hWnd;
	// �������
	event = CreateEvent(NULL, TRUE, FALSE, L"Serv1");

	// ������ ������
	WORD wVersionRequested = MAKEWORD(1, 1);
	// ������������� ������
	if (WSAStartup(wVersionRequested, &wsaData))
	{
		MessageBox(0, L"�� �������������� �����!" + int(WSAGetLastError), 0, MB_OK);
		WSACleanup();
	}

	// �������� ������
	listener = socket(AF_INET, SOCK_STREAM, NULL);

	// ��������� ��������� ������
	ZeroMemory(&addr, sizeof(addr));
	addr.sin_family = AF_INET;
	addr.sin_port = htons(3000);
	addr.sin_addr.s_addr = htonl(INADDR_ANY);	// ������ ��������� ����������� �� ��� ip-������
	socket_name_size = sizeof(addr);

	//������ ��������
	if (bind(listener, (struct sockaddr *)&addr, socket_name_size)<0)
	{
		MessageBox(0, L"����� �� binding", 0, MB_OK);
		exit(1);
	}

	// �������� �������� ���������� - 1
	listen(listener, 1);
	MessageBox(0, L"����������� �������������", L"����������", MB_OK);

	// ������� ����� � ������� Thread
	HANDLE tr = HANDLE(_beginthread(Thread, 0, NULL));
	//WaitForSingleObject(tr, 0);
	while (true) {
		if (k == true) break;
	}
}