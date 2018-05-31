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

// ������������� ������
void StartSocket()
{
	WSADATA wsaData;
	WORD wVersionRequested = MAKEWORD(1, 1);	// ������ �������

	if (WSAStartup(wVersionRequested, &wsaData))
	{
		error = WSAGetLastError();
		MessageBox(0, L"������ ������������� ������\n", 0, MB_OK);
		WSACleanup();
	}
}

// �������� ������, � �������� ����� ������������
int CreateSocket(int port)
{
	char HostName[1024];
	hostent* hn;
	LPHOSTENT lphost;

	/// ������� ����� ///
	
	servsocket = socket(AF_INET, SOCK_STREAM, 0);
	if (servsocket == INVALID_SOCKET)
	{
		MessageBox(0, L"������ �������� ������\n", 0, MB_OK);
		return 2;
	}

	/// ��������� ��������� ������ ///

	ZeroMemory(&serv_addr, sizeof(serv_addr));
	// ��� ������ (TCP/IP)
	serv_addr.sin_family = AF_INET;
	// �������� hostname �� ����� 3000 (���� ����� ������������)
	gethostname(HostName, port);
	lphost = gethostbyname(HostName);
	// �������� ��� ip-������ ����������� � ���������
	serv_addr.sin_addr.S_un.S_addr = *(DWORD*) lphost->h_addr_list[0];
	// ����, � �������� ������������
	serv_addr.sin_port = htons(port);

	/// ������������ � ������ ///

	if (SOCKET_ERROR == (connect(servsocket, (sockaddr *)&serv_addr, sizeof(serv_addr))))
	{
		error = WSAGetLastError();
		MessageBox(0, L"������ ����������", 0, MB_OK);
		return 2;
	}
	MessageBox(0, L"���������� �����������\n", L"����������", MB_OK);
}

// ��������� ������ � ����
void Draw(HDC hdc, char* szText, int left, int top, int right, int bottom) 
{
	LOGFONTW lfFont;
	HFONT hFontOld = NULL;
	static HFONT hFont = NULL;
	wchar_t wtext[50];
	LPWSTR ptr;
	_locale_t locale;
	DWORD clrText;

	// �������������, � �������� �������� ��������� �����
	RECT rect = { left, top, right, bottom };

	ZeroMemory(&lfFont, sizeof(lfFont));
	// ������ � �����
	lfFont.lfHeight = 18;
	lfFont.lfWeight = FW_NORMAL;
	hFont = CreateFontIndirectW(&lfFont);
	if (hFont != NULL) hFontOld = static_cast<HFONT>(SelectObject(hdc, hFont));
	// ���� ������
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

// ����� 1��� �������
void opros1(HWND hWnd) {
	char buff[80];
	int actual_len = 0;
	char result[80];
	HANDLE event1;

	// ���������
	PAINTSTRUCT ps;
	HDC hdc = BeginPaint(hWnd, &ps);

	shutdown(servsocket, 2);
	WSACleanup();
	InvalidateRect(hWnd, 0, TRUE);
	UpdateWindow(hWnd);

	event1 = CreateEvent(NULL, TRUE, FALSE, L"Serv1");
	StartSocket();
	if (CreateSocket(3000) == 2) return;

	MessageBox(0, L"������������ � ������� 1", L"������ 1", 0);

	// ������� ������� �������
	SetEvent(event1);
	
	if (SOCKET_ERROR == (actual_len = recv(servsocket, buff, sizeof(buff) - 1, 0)))
	{
		error = WSAGetLastError();
		MessageBox(0, L"recv error ", 0, MB_OK);
		exit(1);
	}

	Rectangle(hdc, 98, 98, 452, 402);
	Rectangle(hdc, 598, 98, 1002, 402);

	/// ������ ������ ///

	strcpy(result, "���� COLOR_MENUTEXT: ");
	strcat(result, buff);
	Draw(hdc, result, 100, 100, 450, 300);

	if (SOCKET_ERROR == (actual_len = recv(servsocket, buff, sizeof(buff) - 1, 0)))
	{
		error = WSAGetLastError();
		MessageBox(0, L"recv error ", 0, MB_OK);
		exit(1);
	}
	strcpy(result, "���� COLOR_MENU: ");
	strcat(result, buff);
	Draw(hdc, result, 100, 200, 450, 400);

	/// ������ ������ ///

	if (SOCKET_ERROR == (actual_len = recv(servsocket, buff, sizeof(buff) - 1, 0)))
	{
		error = WSAGetLastError();
		MessageBox(0, L"recv error ", 0, MB_OK);
		exit(1);
	}
	strcpy(result, "����: ");
	strcat(result, buff);
	Draw(hdc, result, 600, 100, 1000, 500);

	// ����������� ������� ������� ������� � ����������� ���������
	ResetEvent(event1);
	EndPaint(hWnd, &ps);
}

// ����� 2��� �������
void opros2(HWND hWnd) {
	char buff[80];
	int actual_len = 0;
	char result[80];
	HANDLE event2;

	// ���������
	PAINTSTRUCT ps;
	HDC hdc = BeginPaint(hWnd, &ps);

	shutdown(servsocket, 2);
	WSACleanup();
	InvalidateRect(hWnd, 0, TRUE);
	UpdateWindow(hWnd);

	event2 = CreateEvent(NULL, TRUE, FALSE, L"Serv2");
	StartSocket();
	if (CreateSocket(1234) == 2) return;
	
	MessageBox(0, L"������������ � ������� 2", L"������ 2", 0);

	SetEvent(event2);
	
	/// ������ ������ ///

	if (SOCKET_ERROR == (actual_len = recv(servsocket, buff, sizeof(buff) - 1, 0)))
	{
		error = WSAGetLastError();
		MessageBox(0, L"recv error ", 0, MB_OK);
		exit(1);
	}

	Rectangle(hdc, 98, 98, 502, 502);
	Rectangle(hdc, 598, 98, 1002, 502);

	strcpy(result, "������������� �������� ��������: ");
	strcat(result, buff);
	Draw(hdc, result, 100, 100, 500, 500);

	/// ������ ������ ///

	if (SOCKET_ERROR == (actual_len = recv(servsocket, buff, sizeof(buff) - 1, 0)))
	{
		error = WSAGetLastError();
		MessageBox(0, L"recv error ", 0, MB_OK);
		exit(1);
	}
	strcpy(result, "���������� �������� ��������: ");
	strcat(result, buff);
	Draw(hdc, result, 600, 100, 1000, 500);

	// ����������� ������� ������� ������� � ����������� ���������
	ResetEvent(event2);
	EndPaint(hWnd, &ps);
}