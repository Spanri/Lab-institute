; y=(A+B)*X+C*X
; A,B,X,C - однобайтовые числа со знаком

model small
stack 100h
.data
a db -7h ;10111 (F9)
b db 0ch ;01000 (12)
c db 3h ;00011
x db -5h ;10101 (FB)
y dw ?
.code
start:
    mov ax,@data    ;начало кода
    mov ds,ax       ;указывает на начало сегмента данных

    mov ax,0h
    mov al,a
    add al,b        ;прибавляем к al=a b (F9+C=5)
    imul x          ;умножаем al=a+b на x и кладем в ax (5*FB=E7=-25)
    mov y,ax

    mov ax,0h
    mov al,c
    imul x          ;умножаем al=c на x и кладем в ax (3*FB=F1=-15)
    add al,c        ;прибавляем к al c (F1+3=F4=-12)
    add y,ax        ;E7+F4=DB=-37

    mov ax,4c00h
    int 21h
end start