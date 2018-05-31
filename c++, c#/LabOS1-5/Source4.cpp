#include <windows.h>
#include <iostream>
#include <process.h>
#include <iomanip> 
#include <conio.h>
#include <cstdio>
#include <tlhelp32.h>

#define TCHAR wchar_t
#define cout wcout
#define cin wcin
#define TEXT(p) L##p

using namespace std;
#include <stdio.h>

HANDLE console = GetStdHandle(STD_OUTPUT_HANDLE);

void Diagr(int d) {
	SetConsoleTextAttribute(console, 11);
	for (int i = 0;i < 50;i++) {
		if (i == d / 2) SetConsoleTextAttribute(console, 15);
		cout << TEXT("|");
	}
	SetConsoleTextAttribute(console, 15);
	cout << " " << d << endl;
}

int main4() {
	setlocale(LC_ALL, "Russian");

	/// ���������� �� GlobalMemoryStatus ///

	MEMORYSTATUS stat;
	ZeroMemory(&stat, sizeof(stat));
	stat.dwLength = sizeof(stat);
	GlobalMemoryStatus(&stat);
	int proc;

	SetConsoleTextAttribute(console, 15);

	cout << TEXT("MemoryStatus �������� ") << stat.dwLength << TEXT(" ����.") << endl;
	cout << TEXT("������ ��������� �� ") << stat.dwMemoryLoad << TEXT("%.") << endl;
	Diagr(stat.dwMemoryLoad);

	cout << TEXT("���������� ������\n����� - ") << stat.dwTotalPhys / 1024 / 1024 << TEXT(" �����.\n");
	cout << TEXT("�������� - ") << stat.dwAvailPhys / 1024 / 1024 << TEXT(" �����.\n");
	double proc1 = stat.dwAvailPhys / 1024;
	double proc2 = stat.dwTotalPhys / 1024;
	proc = proc1 / proc2 * 100;
	Diagr(proc);

	cout << TEXT("�����, ������� ����� ��������� �����/���� ��������\n����� - ") << stat.dwTotalPageFile / 1024 / 1024 << TEXT(" �����.\n");
	cout << TEXT("�������� - ") << stat.dwAvailPageFile / 1024 / 1024 << TEXT(" �����.\n");
	proc1 = stat.dwTotalPageFile / 1024;
	proc2 = stat.dwAvailPageFile / 1024;
	proc = proc2 / proc1 * 100;
	Diagr(proc);

	cout << TEXT("����������� ������:\n����� - ")  << stat.dwTotalVirtual / 1024 / 1024 << TEXT(" �����.\n");
	cout << TEXT("�������� - ") << stat.dwAvailVirtual / 1024 / 1024 << TEXT(" �����.\n");
	proc1 = stat.dwTotalVirtual / 1024;
	proc2 = stat.dwAvailVirtual / 1024;
	proc = proc2 / proc1 * 100;
	Diagr(proc);

	/// ����� ����������� ������ ///

	system("pause");
	system("cls");

	SetConsoleTextAttribute(console, 11);
	cout << TEXT("���  ��������, ������, ������ � �� ��������  � �������:\n");
	cout << setiosflags(ios::left) << setw(33) << TEXT("��� ��������")
		<< setw(10) << TEXT("PID") << endl;
	SetConsoleTextAttribute(console, 15);

	/// �������� ///

	HANDLE all = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	if (all == NULL) {
		return 0;
		cout << TEXT("�� �����.");
	}
	PROCESSENTRY32 proc0;
	proc0.dwSize = sizeof(PROCESSENTRY32);
	if (Process32First(all, &proc0)) {
		do {
			cout << setw(33) << proc0.szExeFile;
			cout << setw(10) << proc0.th32ProcessID << endl;
		} while (Process32Next(all, &proc0));
	}
	CloseHandle(all);

	HANDLE hProcess;
	int id;
	SetConsoleTextAttribute(console, 11);
	cout << TEXT("����� ������� �����������? ") << endl;
	SetConsoleTextAttribute(console, 15);
	cin >> id;

	/// ����� ///

	hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, id);

	MEMORY_BASIC_INFORMATION meminfo;
	UINT adr = 0;
	ZeroMemory(&meminfo, sizeof(meminfo));

	cout << TEXT("������� �����") << TEXT("\t") << TEXT("AllocationProtect") << TEXT("\t") 
		<< TEXT("������ �������") << TEXT("\t") << TEXT("State") << endl;

	while (adr < 0x7FFFFFF) {
		VirtualQueryEx(hProcess, (void*)adr, &meminfo, sizeof(meminfo));
		cout << TEXT("0x") << hex << adr << dec
			<< TEXT("\t") << meminfo.AllocationProtect << TEXT("\t\t\t") << meminfo.RegionSize << TEXT("\t\t");
		switch (meminfo.State) {
		case MEM_FREE:
			cout << TEXT("free");
			break;
		case MEM_RESERVE:
			cout << TEXT("reserve");
			break;
		case MEM_COMMIT:
			cout << TEXT("commit");
			break;
		}
		cout << endl;
		adr = adr + meminfo.RegionSize;
	}

	system("pause");
	return 0;
}