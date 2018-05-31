#include "Header.h"

//Делаем set все 0 (начальный автомат)
void nul(int* set) {
	for (int i = 0;i<8;i++) set[i] = 0;
}

//Добавляем set еще одну 1
void incSet(int* set) {
	for (int i = 0;i < 8;i++)
		if (set[i] == 0) {
			set[i] = 1;
			return;
		}
		else if (set[i] == 1) {
			set[i] = 0;
			if (set[i + 1] == 0) {
				set[i + 1] = 1;
				return;
			}
		}
		else return;
}

//преобразование
void conv(int* vec, int* set) {
	for (int i = 0;i < N;i++) {
		if (vec[i] == 0 && vec[i + 1] == 0 && vec[i + 2] == 0) vec[i] = set[0];
		else if (vec[i] == 0 && vec[i + 1] == 0 && vec[i + 2] == 1) vec[i] = set[1];
		else if (vec[i] == 0 && vec[i + 1] == 1 && vec[i + 2] == 0) vec[i] = set[2];
		else if (vec[i] == 0 && vec[i + 1] == 1 && vec[i + 2] == 1) vec[i] = set[3];
		else if (vec[i] == 1 && vec[i + 1] == 0 && vec[i + 2] == 0) vec[i] = set[4];
		else if (vec[i] == 1 && vec[i + 1] == 0 && vec[i + 2] == 1) vec[i] = set[5];
		else if (vec[i] == 1 && vec[i + 1] == 1 && vec[i + 2] == 0) vec[i] = set[6];
		else if (vec[i] == 1 && vec[i + 1] == 1 && vec[i + 2] == 1) vec[i] = set[7];
	}
}