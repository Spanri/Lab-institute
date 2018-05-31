;Составьте программу, которая пересылает слово из стека в память,
;на место третьего элемента массива

model small
stack 100h
.data
massiv dw 10h,20h,30h,40h
slovo dw 25h
.code
start:
    mov ax,@data    ;начало кода
    mov ds,ax       ;указывает на начало сегмента данных
    mov di,0004
    push slovo      ;записываем слово в стек
    pop massiv[di]  ;берем слово из стека и кладем в 3ий элемент массива
    mov ax,4c00h
    int 21h
end start