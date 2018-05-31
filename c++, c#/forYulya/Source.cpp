#include <conio.h>
#include <stdlib.h>
#include <iostream>
using namespace std;

int main() {
	//��� ��� ��� ������� - �������, �� � ����������� ���� ���
	int n = 5;
	int** mas = new int*[n];

	//��������� ������
	for (int i = 0; i < n; i++)
		mas[i] = new int[n];

	//������ ������ (����� enter)
	/*for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			cin >> mas[i][j];*/

	//������ ������� �����, ��������� �����, ����� ������� �� ���������
	//�� ������ ��� ���� � �� �� ������, ��� � srand ���������� 
	//����� ��� ������ �������
	srand(11); // ������������ ���������� ��������� �����
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			mas[i][j] = 1 + rand() % 10; //�� 1 �� 10
			
	//������� ������
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++)
			cout << mas[i][j] << " ";
		cout << endl;
	}

	//��� 2 �������, ����� ������ ������� (������)
	int sum = 0, sum21 = 0, sum22 = 0;
	for (int i = 0; i < n; i++)
		sum21 += mas[i][0];

	int k1 = 0, k2 = 0, k3 = 0;

	//1 �������
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++)
			if (i != j && mas[i][j] != mas[j][i]) k1 = 1;

	//2 �������
	//��� ����� (sum21) � �������� (sum22)
	for (int i = 0; i < n; i++) {
		sum21 = sum22 = 0;
		for (int j = 0; j < n; j++) {
			sum21 += mas[j][i];
			sum22 += mas[i][j];
		}
		if (sum != sum21 && sum != sum22) k2 = 1;
	}
	//��� ���������
	sum21 = 0;
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++)
			if(i == j) sum21 += mas[i][j];
	}
	if (sum != sum21) k2 = 1;
	//��� ������ ���������
	sum21 = 0;
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++)
			//�������� 0 + 4 = 5 - ��������� ������� � ������ ������
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