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

	/// Создать объект file ///

	// так как OPEN_EXISTING, то сработает,
	// только если файл уже создан
	HANDLE file = CreateFile(
		L"C:/Users/Spanri/Desktop/file.txt",
		GENERIC_READ | GENERIC_WRITE,
		0,
		NULL,
		OPEN_EXISTING,
		FILE_ATTRIBUTE_NORMAL,
		NULL);
	// если ошибка
	if (file == INVALID_HANDLE_VALUE) {
		cout << "Ошибка - ";
		switch (GetLastError()) {
		case ERROR_FILE_NOT_FOUND:
			cout << "Файл не найден" << endl;
			break;
		case ERROR_PATH_NOT_FOUND:
			cout << "Путь не найден" << endl;
			break;
		default:
			cout << GetLastError() << endl;
		}
		CloseHandle(file);
		system("pause");
		return 0;
	}
	cout << "Дескриптор " << file << endl;

	/// Отобразить части файла в память ///

	// получить размер файла file.txt
	DWORD dwFileSize = GetFileSize(file, NULL);
	if (dwFileSize == INVALID_FILE_SIZE) {
		cout << "fileMappingCreate - GetFileSize failed";
		CloseHandle(file);
		system("pause");
		return 0;
	}

	// создание отображения файла в память
	HANDLE fileMap = CreateFileMapping(
		file, //дескриптор от CreateFile
		NULL, 
		PAGE_READWRITE, 
		0, 
		dwFileSize, 
		NULL);
	if (fileMap == NULL) {
		cout << "Ошибка CreateFileMapping - ";
		switch (GetLastError()) {
		case ERROR_FILE_NOT_FOUND:
			cout << "Файл не найден" << endl;
			break;
		case ERROR_PATH_NOT_FOUND:
			cout << "Путь не найден" << endl;
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
	cout << "Дескриптор файлового отображения " << hex << fileMap << endl;

	// отображение файла в память
	LPVOID mapView = MapViewOfFile(
		fileMap, //дескриптор от CreateFileMapping
		FILE_MAP_ALL_ACCESS,
		0, 
		0, 
		0);
	if (mapView == NULL) {
		cout << "Ошибка MapViewOfFile - ";
		switch (GetLastError()) {
		case ERROR_FILE_NOT_FOUND:
			cout << "Файл не найден" << endl;
			break;
		case ERROR_PATH_NOT_FOUND:
			cout << "Путь не найден" << endl;
			break;
		case ERROR_INVALID_HANDLE:
			cout << "Невалидный handle" << endl;
			break;
		default:
			cout << GetLastError() << endl;
		}
		CloseHandle(fileMap);
		system("pause");
		return 0;
	}
	cout << "MapViewOfFile " << mapView << endl;

	// копируем область памяти из файлового отображения в masMem
	char *masMem = new char[dwFileSize];
	CopyMemory(masMem, mapView, dwFileSize);

	// изменяем регистр
	for (int i = 0;i < dwFileSize;i++) {
		char sym = masMem[i];
		if (isupper(sym))
			masMem[i] = tolower(sym);
		else
			masMem[i] = toupper(sym);
	}

	// обратно в файл
	CopyMemory(mapView, masMem, dwFileSize);
	cout << "Регистр изменен" << endl;

	// закрываем дескрипторы
	if (!UnmapViewOfFile(mapView))
		cout << "Что-то не то при освобождении памяти..." << endl;
	else
		cout << "Освободили память" << endl;

	if(!CloseHandle(fileMap))
		cout << "Что-то не то при закрытии файлового отображения..." << endl;
	else
		cout << "Закрыли файловое отображение" << endl;

	if (!CloseHandle(file))
		cout << "Что-то не то при закрытии файла..." << endl;
	else
		cout << "Закрыли файл" << endl;

	system("pause");
	return 0;
}