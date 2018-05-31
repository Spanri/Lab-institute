;Составьте программу преобразования элементов исходного массива xi размерностью 9
;в новый массив yi в соответствии с выражением:
;n=9 двухбайтных чисел со знаком
;yi = xi - 1

model small
stack 100h
.data
mas dw 1h,-2h,3h,-4h,5h,-6h,7h,-8h,9h
mas2 dw 9 dup(?) 
len equ 9
.code
start:
    mov ax,@data    ;начало кода
    mov ds,ax       ;указывает на начало сегмента данных
    mov cx,len      ;cx - счетчик цикла
    xor ax,ax
    xor si,si       ;обнуление si - индекс для массива
l1:
    mov ax, mas[si]   
    sub ax, 1       ;yi = xi - 1
    mov mas2[si],ax
    add si,2        ;+1 к счетчику
    loop l1         ;уменьшаем счетчик цикла cx на 1

    mov ax,4c00h
    int 21h
end start