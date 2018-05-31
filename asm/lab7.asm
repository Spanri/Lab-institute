;Составьте программу, которая предварительно очистив экран,
;помещает в заданной позиции экрана текст, вводимый с
;клавиатуры. "Студент группы БВТ1501 Козлова Анна Сергеевна"
;Строка - 04, столбец - 16

model small
stack 100h
.data
str1 db 'Student of BVT1501 ', '$'
str2 db 100, 100 dup ('$')
NAMEPAR LABEL BYTE
MAXLEN DB 100
ACTLEN DB ?
NAMEFLD DB 20 DUP('')
.code
    assume ds:@data, es:@data
start:
    mov ax,@data
    mov ds,ax
    mov es,ax

    ;очистка экрана
    mov ax, 0600h
    mov bh, 07
    mov ax, 0000
    mov dx, 184fh
    int 10h

    ;установить курсор
    mov ah, 02
    mov bh, 00
    mov dh, 04
    mov dl, 35
    int 10h

    ;вывод в консоль
    ;mov ah, 09h
    ;lea dx, str1
    ;int 21h

    ;ввод текста
    mov ah, 0ah
    lea dx, str2
    int 21h

    mov str2+1,0ah

    ;установить курсор
    mov ah, 02
    mov bh, 00
    mov dh, 06
    mov dl, 00
    int 10h

    ;вывод в консоль
    mov ah, 09h
    lea dx, str2
    int 21h

    mov ax, 4c00h
    int 21h
end start