#include <iostream>
#include <conio.h>
#include <math.h>
#include <time.h>
#define dlina 10000
#define dlina2 20000
using namespace std;

void main()
{
	setlocale(LC_ALL, "rus");
	srand(time(0));
	double mas[dlina2], t[dlina], tau[dlina];

	//ШАГ 1
	for (int i = 0; i<dlina2; i++)
		mas[i] = ((double)rand()*0.999999 / RAND_MAX) + 0.00000001;
	int k = 0;
	for (int i = 0; i<20; i++) {
		cout << mas[i] << " ";
		k++;
		if (k == 8) {
			cout << endl;
			k = 0;
		}
	}
	cout << endl;

	//ШАГ 2
	for (int i = 0; i<dlina; i++)
		if (mas[i + dlina]>0.5)	tau[i] = -(1. / 3.)*log(mas[i]);
		else tau[i] = -(1. / (3. / 2.))*log(mas[i]);;
		t[0] = tau[0];
		for (int i = 1; i<dlina; i++)
			t[i] = t[i - 1] + tau[i];

		//ШАГ 3
		cout << "t" << "\t   " << "tau" << endl;
		for (int i = 0; i<20; i++)	cout << t[i] << "   " << tau[i] << endl;

		//ШАГ 4
		//1.
		double MX = 0;
		for (int i = 0; i<dlina; i++)
			MX += tau[i];
		MX = MX / dlina;
		cout << endl << "Матожидание: " << endl << MX << endl;

		//2.
		double DX = 0;
		for (int i = 0; i<dlina; i++)
			DX += pow((tau[i] - MX), 2);
		DX = DX / (dlina - 1);
		cout << "Дисперсия: " << endl << DX << endl;

		//3.
		double cov = 0;
		for (int i = 1; i<dlina; i++)
			cov += (tau[i] - MX)*(tau[i - 1] - MX);
		cov = cov / (dlina - 1);
		double cor = cov / DX;
		cout << "Коэффициент корреляции:" << endl << cor << endl;
		double buf2 = pow(cor, 2);
		buf2 = 1 - buf2;
		cor = cor*sqrt((double)9998) / sqrt(buf2);
		cout << "Критерий:" << endl << cor << endl;

		//4.
		double Teor[10], Emp[10], TeorP[10];
		double j = 0;
		for (int i = 0; i<10; i++)
		{
			TeorP[i] = (1 - 0.5*exp(-3 * (j + 0.1)) - 0.5*exp((-3 * (j + 0.1)) / 2)) - (1 - 0.5*exp(-3 * j) - 0.5*exp((-3 * j) / 2));
			j += 0.1;
		}
		for (int i = 0; i<10; i++)
			Teor[i] = Emp[i] = 0;

		int buf;
		for (int i = 0; i<dlina; i++)
		{
			buf = tau[i] * 10;
			if (buf<10)
				Emp[buf]++;
		}
		for (int i = 0; i<10; i++)
			Teor[i] = dlina*TeorP[i];

		cout << endl << "Частота:" << endl << "Эмп.:" << '\t' << "Теор.:" << endl;
		for (int i = 0; i<10; i++)
			cout << Emp[i] << '\t' << Teor[i] << endl;
		double xi = 0;
		for (int i = 0; i<10; i++)
			xi += pow((Emp[i] - Teor[i]), 2) / Teor[i];
		cout << endl << "X^2" << endl << xi;
		_getch();
}

