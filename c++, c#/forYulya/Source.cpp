#include <conio.h>
#include <stdlib.h>
#include <iostream>
using namespace std;

int main() {
	//так как тут матрица - квадрат, то и размерность один раз
	int n = 5;
	int** mas = new int*[n];

	//объ€вл€ем массив
	for (int i = 0; i < n; i++)
		mas[i] = new int[n];

	//вводим массив (через enter)
	/*for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			cin >> mas[i][j];*/

	//другой вариант ввода, рандомные числа, чтобы вручную не заполн€ть
	//он каждый раз одно и то же выдает, ибо в srand одинаковое 
	//число при каждом запуске
	srand(11); // рандомизаци€ генератора случайных чисел
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			mas[i][j] = 1 + rand() % 10; //от 1 до 10
			
	//выводим массив
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++)
			cout << mas[i][j] << " ";
		cout << endl;
	}

	//дл€ 2 задани€, сумма одного столбца (любого)
	int sum = 0, sum21 = 0, sum22 = 0;
	for (int i = 0; i < n; i++)
		sum21 += mas[i][0];

	int k1 = 0, k2 = 0, k3 = 0;

	//1 задание
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++)
			if (i != j && mas[i][j] != mas[j][i]) k1 = 1;

	//2 задание
	//дл€ строк (sum21) и столбцов (sum22)
	for (int i = 0; i < n; i++) {
		sum21 = sum22 = 0;
		for (int j = 0; j < n; j++) {
			sum21 += mas[j][i];
			sum22 += mas[i][j];
		}
		if (sum != sum21 && sum != sum22) k2 = 1;
	}
	//дл€ диагонали
	sum21 = 0;
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++)
			if(i == j) sum21 += mas[i][j];
	}
	if (sum != sum21) k2 = 1;
	//дл€ другой диагонали
	sum21 = 0;
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++)
			//например 0 + 4 = 5 - последний элемент в первой строке
			if (i + j + 1 == n) sum21 += mas[i][j];
	}
	if (sum != sum21) k2 = 1;


	if (k1 == 0) cout << "Sim";
	else cout << "No sim";

	if (k2 == 0) cout << "Magic";
	else cout << "No magic";

	system("pause");
	return 0;
}