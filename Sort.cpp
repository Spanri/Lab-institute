#include <iostream>
#include <conio.h>
#include <math.h>
#include <ctime>
#include <time.h>
using namespace std;

int h;

void swap(int& a, int& b) {
	int t;
	t = b;
	b = a;
	a = t;
	h++;
}

//���������
void Sort0(int* mas, int n) {
	for (int i = 0; i < n-1; i++) {
		for (int j = i+1; j < n; j++) {
			if (mas[i]> mas[j]) swap(mas[j], mas[i]);
		}
	}
}

void Sort1(int* mas, int n) {
	int p = mas[0]; //������� �������
	long i = 0, j = n - 1; //�������� ��� ���������

	do {
		//��������� �� 2 �������
		while (mas[i] < p) i++;
		while (mas[j] > p) j--;

		if (i <= j) {
			swap(mas[i], mas[j]);
			
				i++;
				j--;
			
		}
	} while (i <= j);

	//������� Sort ��� ������ ���������
	if (j > 0)	Sort1(mas, j + 1);
	if (n > i)	Sort1(mas + i, n - i);
}

void Sort2(int* mas, int n) {
	int p = mas[n - 1]; //������� �������
	long i = 0, j = n - 1; //�������� ��� ���������

	//6 3 7 5 9 1 2 = 6

	do {
		//��������� �� 2 �������
		while (mas[i] < p) i++;
		while (mas[j] > p) j--;

		if (i <= j) {
			swap(mas[i], mas[j]);
			i++;
			j--;
		}
	} while (i <= j);

	//������� Sort ��� ������ ���������
	if (j > 0)	Sort2(mas, j + 1);
	if (n > i)	Sort2(mas + i, n - i);
}

void Sort11(int* mas, int n) {
	int p = mas[n >> 1]; //������� �������
	long i = 0, j = n - 1; //�������� ��� ���������

	do {
		//��������� �� 2 �������
		while (mas[i] < p) i++;
		while (mas[j] > p) j--;

		if (i <= j) {
			swap(mas[i], mas[j]);
			i++;
			j--;
		}
	} while (i <= j);

	//������� Sort ��� ������ ���������
	if (j > 0)	Sort11(mas, j + 1);
	if (n > i)	Sort11(mas + i, n - i);
}

void Sort30(int* mas, int n, int k, int h) {
	for (int i = h; i < n - 1; i += k) {
		for (int j = i + k; j < n; j += k) {
			if (mas[i]> mas[j]) swap(mas[j], mas[i]);
		}
	}
}

//�����
void Sort32(int* mas, int n) {
	int k = n;
	while (k > 1) {
		if (k % 2 == 1 && k != 1) k++;
		k = k / 2;
		for (int h = 0; h < k; h++) Sort30(mas, n, k, h);
	};

}

void MainSort(int mas[],int mas0[],int n, int l) {
	clock_t t0;
	double t = 0;
	for (int i = 0; i < 10000; i++) {
		if (l == 0) {
			t0 = clock();
			Sort0(mas, n);
		}else
		if (l == 1) { 
			t0 = clock();
			Sort1(mas, n);
		}else
		if (l == 11) {
			t0 = clock();
			Sort11(mas,n);
		}else
		if (l == 2) {
			t0 = clock();
			//Sort2(mas, mas[0], mas[n], mas[0]);
			Sort2(mas, n);
		}else
		if (l == 32) {
			t0 = clock();
			Sort32(mas, n);
		}
		t += clock() - t0;
		for (int i = 0; i < n; i++) mas[i] = mas0[i];
	}
	h = 0;
	if (l == 0) {
		Sort0(mas, n);
		cout << "�������\n";
	}
	if (l == 1) { 
		Sort1(mas, n);
		cout << "\n�������, 1�� �������\n";
	}
	if (l == 11) {
		Sort11(mas, n);
		cout << "\n�������, ������� �������\n";
	}
	if (l == 2) {
		Sort2(mas, n);
		cout << "\n�������, ����. �������\n";
	}
	if (l == 32) {
		Sort32(mas, n);
		cout << "\n�����\n";
	}
	//t = ((double)t) / CLOCKS_PER_SEC * 1000;
	for (int i = 0; i < n; i++)	cout << mas[i] << " ";
	cout << "\t��������:" << h << ", �����: " << t << "ms";
	for (int i = 0; i < n; i++) mas[i] = mas0[i];
}

void main()
{
	srand(time(0)); //���� ������ ��� ������ �����
	setlocale(LC_ALL, "Rus"); //�������
	int n;
	int t0, t = 0;
	int r = 10000;

	cout << "������� ����� �������������?\n";
	cin >> n;
	int* mas = new int[n];
	int* mas0 = new int[n];

	//���������� �����
	cout << "����: \n";
	for (int i = 0; i < n; i++) {
		mas[i] = rand() % (4*n); //������ �� 0 �� 50
		cout << mas[i] << " ";
	}
	cout << "\n" << "\n";
	for (int i = 0; i < n; i++) {
		mas0[i] = mas[i];
	}

	//�������� Sort
	MainSort(mas, mas0, n, 0);
	MainSort(mas, mas0, n, 1);
	MainSort(mas, mas0, n, 11);
	MainSort(mas, mas0, n, 2);
	MainSort(mas, mas0, n, 32);

	delete[] mas;
	delete[] mas0;

	_getch();
}
