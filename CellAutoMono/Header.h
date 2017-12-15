#pragma once
#include <iostream>
#include <conio.h>
#include <time.h>
using namespace std;
#define N 902
#define M 900

void nul(int* set);
void conv(int* vec, int* set);
void incSet(int* set);
bool more(int* vec, int* vec2, int* set, int& k);
bool les(int* vec, int* vec2, int* set, int& k);
bool cons(int* vec, int* vec2, int* set, int& k);
