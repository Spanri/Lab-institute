#include "Header.h"

bool more(int* vec, int* vec2, int* set, int& k) {
	int one[50];
	one[0] = k;
	for(int i=1;i<50;i++){
		one[i] = 0;
		conv(vec, set);
		for (int j = 0;j < M;j++)	if (vec[j] == 1) one[i]++;
		k = one[i];
		if (one[i] <= one[i - 1]) {
			if (one[i] == M && one[i] == M) return true;
			return false;
		}
	}
	return true;
}

bool les(int* vec, int* vec2, int* set,int& k) {
	int one[50];
	one[0] = k;
	for (int i = 1;i<50;i++) {
		one[i] = 0;
		conv(vec, set);
		for (int j = 0;j < M;j++)	if (vec[j] == 1) one[i]++;
		k = one[i];
		if (one[i] >= one[i - 1]) {
			if (one[i] == 0 && one[i] == 0) return true;
			return false;
		}
	}
	return true;
}

bool cons(int* vec, int* vec2, int* set, int& k) {
	int one[50];
	one[0] = k;
	for (int i = 1;i<50;i++) {
		one[i] = 0;
		conv(vec, set);
		for (int j = 0;j < M;j++)	if (vec[j] == 1) one[i]++;
		k = one[i];
		if (one[i] != one[i - 1]) {
			if (one[i] == 0 && one[i] == 0) return true;
			return false;
		}
	}
	return true;
}

