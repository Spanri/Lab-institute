#include <windows.h>
#include <iostream>
#include <conio.h>
#define TCHAR wchar_t
#define cout wcout
#define cin wcin
#define TEXT(p) L##p
using namespace std;

int main1() {
	setlocale(LC_ALL, "Russian");

	TCHAR buffer[512];
	DWORD size = 512;
	OSVERSIONINFO osversion;
	ACCESSTIMEOUT access;
	int sysparam;

	if(!GetComputerName(buffer, &size))
		cout << TEXT("error of GetComputerName");
	cout << TEXT("��� ����������: \t\t\t") << buffer << endl;

	if (!GetSystemDirectory(buffer, 512))
		cout << TEXT("error of GetSystemDirectory");
	cout << TEXT("���� � ���������� ��������: \t\t") << buffer << endl;

	if(!GetWindowsDirectory(buffer, 512))
		cout << TEXT("error of GetWindowsDirectory");
	cout << TEXT("���� � ��������: \t\t\t") << buffer << endl;

	if (!GetTempPath(512, buffer))
		cout << TEXT("error of GetTempPath");
	cout << TEXT("���� � �������� ���� ������: \t\t") << buffer << endl << endl;
	
	memset(&osversion, 0, sizeof(OSVERSIONINFO));
	osversion.dwOSVersionInfoSize = sizeof(OSVERSIONINFO);
	GetVersionEx((OSVERSIONINFO*)&osversion);
	cout << TEXT("������ �������: \t\t\t") << osversion.dwMajorVersion << "." << osversion.dwMinorVersion << "." << osversion.dwBuildNumber << " (Win Server 2012 / Win 8)" << endl
		<< TEXT("������������� ��������� ��: \t\t") << osversion.dwPlatformId << " (VER_PLATFORM_WIN32_NT)" << endl << endl;

	cout << TEXT("���-�� ������ ����: \t\t\t") << GetSystemMetrics(43) << endl
		<< TEXT("������ � ������ ������: \t\t") << GetSystemMetrics(0) << " " << GetSystemMetrics(1) << endl
		<< TEXT("������ ����������� ������� ���������: \t") << GetSystemMetrics(4) << endl << endl;
	
	access.cbSize = sizeof(ACCESSTIMEOUT);
	SystemParametersInfo(SPI_GETACCESSTIMEOUT, sizeof(ACCESSTIMEOUT), &access, 0);
	cout << TEXT("��������� ���������: \t\t\t") << access.iTimeOutMSec << endl;
	SystemParametersInfo(SPI_GETFLATMENU, 0, &sysparam, 0);
	cout << TEXT("Flat ����: \t\t\t\t") << sysparam << endl;
	SystemParametersInfo(SPI_GETBEEP, 0, &sysparam, 0);
	cout << TEXT("������� ���������� �������� ��������: \t") << sysparam << endl << endl;

	int lpaElements[] = { COLOR_MENUTEXT, COLOR_MENU };
	COLORREF color[] = { GetSysColor(COLOR_MENUTEXT), GetSysColor(COLOR_MENU) };
	COLORREF newColor[] = { RGB(255, 0, 0), RGB(0, 255, 0) };
	//COLORREF newColor[] = { RGB(25, 25, 112), RGB(224, 255, 255) };
	SetSysColors(2, lpaElements, newColor);
	cout << TEXT("������ ���� ����� ��������� ���� � ��� ����.") << endl;

	SYSTEMTIME time;
	GetLocalTime(&time);
	cout << endl << TEXT("������� �����: \t\t\t\t")
		<< time.wDay << "." << time.wMonth << "." << time.wYear << endl;
	cout << TEXT("����� ������ �������� ������: \t\t") << GetTickCount() << endl << endl;

	cout << TEXT("������� ������� ��������: \t\t") << GetKBCodePage() << endl;
	cout << TEXT("��������� ID �������: \t\t\t") << GetSystemDefaultLCID() << endl;

	//������ � 16������ �������
	//int caretTime = GetCaretBlinkTime();
	//cout << TEXT("������� �������� ������� �������� �� 100 c ") << caretTime << endl;
	//SetCaretBlinkTime(100);

	int clickTime = GetDoubleClickTime();
	SetDoubleClickTime(10000);
	cout << TEXT("����� �������� ������ �������� �� 1000 � ") << clickTime << endl;

	//���������� �������
	HANDLE hToken;
	TOKEN_PRIVILEGES tkp;
	//�������� �����
	OpenProcessToken(GetCurrentProcess(),
		TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, &hToken);
	//�������� LUID 
	LookupPrivilegeValue(NULL, SE_SHUTDOWN_NAME,
		&tkp.Privileges[0].Luid);
	tkp.PrivilegeCount = 1;  //����������   
	tkp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
	//���������� ��� ����������
	AdjustTokenPrivileges(hToken, FALSE, &tkp, 0,
		(PTOKEN_PRIVILEGES)NULL, 0);
	//���������
	//ExitWindowsEx(EWX_SHUTDOWN, 0);

	system("pause");
	SetSysColors(2, lpaElements, color);
	SetDoubleClickTime(500);
	return 0;
}