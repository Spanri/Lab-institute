#include "Header.h"

void main() {
	setlocale(LC_ALL, "rus");
	srand(time(0));

	int one, one2, on, c = 0, l1, l2, l3;
	int* vec = new int[N];
	int* vec2 = new int[N];
	int* set = new int[8];
	bool b;
	int jm[300];
	int jl[300];
	int jc[300];
	l1 = l2 = l3 = 0;

	do {
		for (int k = 0;k < 300;k++) {
			nul(set);

			for (int i = 0;i < M;i++) vec[i] = 0;
			for (int i = 0;i < 400;i++) vec[rand() % M] = 1;
			vec[M] = vec[0];
			vec[101] = vec[1];

			for (int i = 0;i < N;i++) vec2[i] = vec[i];

			one = 0;
			for (int i = 0;i < M;i++)	if (vec[i] == 1) one++;
			
			for (int j = 0;j < 256;j++) {
				b = false;
				conv(vec, set);
				one2 = 0;
				for (int i = 0;i < M;i++)	if (vec[i] == 1) one2++;

				if (one2 > one) {
					b = more(vec, vec2, set, one2);
					if (b) {
						bool f = true;
						for (int h = 0;h < l1;h++)
							if (jm[h] == j) f = false;
						if (f) {
							jm[l1] = j;
							l1++;
						}
					}
				}
				else if (one2 < one) {
					b = les(vec, vec2, set, one2);
					if (b) {
						bool f = true;
						for (int h = 0;h < l2;h++)
							if (jl[h] == j) f = false;
						if (f) {
							jl[l2] = j;
							l2++;
						}
					}
				}
				else if (one2 == one) {
					b = cons(vec, vec2, set, one2);
					if (b) {
						bool f = true;
						for (int h = 0;h < l3;h++)
							if (jc[h] == j) f = false;
						if (f) {
							jc[l3] = j;
							l3++;
						}
					}
				}

				for (int i = 0;i < N;i++) vec[i] = vec2[i];

				incSet(set);
			}
		}
		cout << "Растет: ";
		for (int i = 0;i < l1;i++) cout << jm[i] << " ";
		cout << "\nПадает: ";
		for (int i = 0;i < l2;i++) cout << jl[i] << " ";
		cout << "\nПостоянно: ";
		for (int i = 0;i < l3;i++) cout << jc[i] << " ";

		cout << "\n1 - repeat\n";
		cin >> c;
	} while (c == 1);
	_getch();
}