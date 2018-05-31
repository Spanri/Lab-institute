#include <iostream> 
#include <conio.h> 
#include <math.h> 
#include <cstdlib> 
#include <time.h> 
using namespace std;

void main()
{
	const int n = 20000;
	//для того, чтобы случайные числа не повторялись каждый раз 
	srand(time(0));

	//создаем массивы и переменную тау 
	double mas[n];
	double mom[n / 2];
	double tu[n / 2];
	double t[n / 2];
	double w[n / 2];
	double sum;
	double dis = 0;

	//генерируем поток от 0 до 1 
	for (int i = 0; i < n; i++) {
		mas[i] = (rand() % 999 + 1) / (1000 * 1.0);
	}
	cout << "massiv: ";
	for (int i = 0; i < 10; i++) cout << mas[i] << " ";

	//моменты поступления заявок
	mom[0] = 0;
	tu[0] = 0;
	for (int i = 1; i < n / 2; i++) {
		tu[i] = tu[i - 1] - log(mas[i]);
		mom[i] = mom[i - 1] - 2.0*log(mas[i + n / 2]);
	}
	//время ожидания
	for (int i = n / 2; i < n; i++) t[i - n / 2] = mas[i];
	//длительность ожидания начала обслуживания
	w[0] = 0;
	sum = 0;
	for (int i = 1; i < n / 2; i++) {
		w[i] = w[i - 1] - (tu[i] - tu[i - 1]) + (mom[i] - mom[i - 1]);
		sum += w[i];
	}
	cout << "\nw: ";
	for (int i = 0; i < 10; i++) cout << w[i] << " ";

	cout << "\nOzidanie: " << sum / (n / 2 - 1) << "\n";

	//нахождение интервалов времени
	double max = w[0];
	for (int i = 1;i<n / 2;i++)
		if (w[i]>max) max = w[i];
	cout << "max: " << max << "\n";
	int nn = max / 1000 + 2;
	double* mas_n = new double[nn];
	int* interval = new int[nn];

	for (int i = 0; i < nn; i++) {
		interval[i] = i * 1000;
		mas_n[i] = 0;
	}
	for (int i = 0; i < n / 2; i++)
		for (int j = 0; j < nn; j++) {
			if ((w[i] >= interval[j]) && (w[i] < interval[j + 1]))
			{
				mas_n[j]++;
				break;
			}
		}
	for (int i = 0; i < nn - 1; i++)
		cout << mas_n[i] << " ";

	_getch();
}