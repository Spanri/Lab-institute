;Составьте программу, которая определяет место первого появления
;первого символа "w" в исходном массиве, содержащем 18
;однобайтных символов

model small
stack 100h
.data
str1 db 'Hello, dear world!'
len equ 18
.code
    assume ds:@data, es@data
main:
    mov ax, @data
    mov ds, ax
    mov es, ax

    cld                  ;поиск вперед по строке
    lea di, str1         ;адрес начала str1 в es:di
    mov al,'w'           ;искомый символ 
    mov cx, len          ;длина str1
    
    repne scasb          ;пока НЕ равны, искать 
    jne k                ;если нашло искомый символ, след строка
    mov bx,di            ;в bx - адрес искомого символа в массиве
k:
    mov ax,4c00h
    int 21h
end main