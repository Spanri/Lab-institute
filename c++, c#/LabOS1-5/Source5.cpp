#include <windows.h>
#include <iostream>
#include <process.h>
#include <iomanip> 
#include <conio.h>
#include <cstdio>
#include <stdio.h>
using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	/// ������� ������ file ///

	// ��� ��� OPEN_EXISTING, �� ���������,
	// ������ ���� ���� ��� ������
	HANDLE file = CreateFile(
		L"C:/Users/Spanri/Desktop/file.txt",
		GENERIC_READ | GENERIC_WRITE,
		0,
		NULL,
		OPEN_EXISTING,
		FILE_ATTRIBUTE_NORMAL,
		NULL);
	// ���� ������
	if (file == INVALID_HANDLE_VALUE) {
		cout << "������ - ";
		switch (GetLastError()) {
		case ERROR_FILE_NOT_FOUND:
			cout << "���� �� ������" << endl;
			break;
		case ERROR_PATH_NOT_FOUND:
			cout << "���� �� ������" << endl;
			break;
		default:
			cout << GetLastError() << endl;
		}
		CloseHandle(file);
		system("pause");
		return 0;
	}
	cout << "���������� " << file << endl;

	/// ���������� ����� ����� � ������ ///

	// �������� ������ ����� file.txt
	DWORD dwFileSize = GetFileSize(file, NULL);
	if (dwFileSize == INVALID_FILE_SIZE) {
		cout << "fileMappingCreate - GetFileSize failed";
		CloseHandle(file);
		system("pause");
		return 0;
	}

	// �������� ����������� ����� � ������
	HANDLE fileMap = CreateFileMapping(
		file, //���������� �� CreateFile
		NULL, 
		PAGE_READWRITE, 
		0, 
		dwFileSize, 
		NULL);
	if (fileMap == NULL) {
		cout << "������ CreateFileMapping - ";
		switch (GetLastError()) {
		case ERROR_FILE_NOT_FOUND:
			cout << "���� �� ������" << endl;
			break;
		case ERROR_PATH_NOT_FOUND:
			cout << "���� �� ������" << endl;
			break;
		case ERROR_ACCESS_DENIED:
			cout << "Access is denied" << endl;
			break;
		default:
			cout << GetLastError() << endl;
		}
		CloseHandle(fileMap);
		system("pause");
		return 0;
	}
	cout << "���������� ��������� ����������� " << hex << fileMap << endl;

	// ����������� ����� � ������
	LPVOID mapView = MapViewOfFile(
		fileMap, //���������� �� CreateFileMapping
		FILE_MAP_ALL_ACCESS,
		0, 
		0, 
		0);
	if (mapView == NULL) {
		cout << "������ MapViewOfFile - ";
		switch (GetLastError()) {
		case ERROR_FILE_NOT_FOUND:
			cout << "���� �� ������" << endl;
			break;
		case ERROR_PATH_NOT_FOUND:
			cout << "���� �� ������" << endl;
			break;
		case ERROR_INVALID_HANDLE:
			cout << "���������� handle" << endl;
			break;
		default:
			cout << GetLastError() << endl;
		}
		CloseHandle(fileMap);
		system("pause");
		return 0;
	}
	cout << "MapViewOfFile " << mapView << endl;

	// �������� ������� ������ �� ��������� ����������� � masMem
	char *masMem = new char[dwFileSize];
	CopyMemory(masMem, mapView, dwFileSize);

	// �������� �������
	for (int i = 0;i < dwFileSize;i++) {
		char sym = masMem[i];
		if (isupper(sym))
			masMem[i] = tolower(sym);
		else
			masMem[i] = toupper(sym);
	}

	// ������� � ����
	CopyMemory(mapView, masMem, dwFileSize);
	cout << "������� �������" << endl;

	// ��������� �����������
	if (!UnmapViewOfFile(mapView))
		cout << "���-�� �� �� ��� ������������ ������..." << endl;
	else
		cout << "���������� ������" << endl;

	if(!CloseHandle(fileMap))
		cout << "���-�� �� �� ��� �������� ��������� �����������..." << endl;
	else
		cout << "������� �������� �����������" << endl;

	if (!CloseHandle(file))
		cout << "���-�� �� �� ��� �������� �����..." << endl;
	else
		cout << "������� ����" << endl;

	system("pause");
	return 0;
}