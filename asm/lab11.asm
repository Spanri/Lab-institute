;преобразуйте 9 лабораторную в программу,
;содержащую макросы

model small
include  macro.asm ;подключаем файл с макросами
stack 100h
.data
;для ввода
NAMEPAR label byte
MAXLEN db 6
ACTLEN db ?
NAMEFLD db 6 dup(' ')
;кол-во символов в строке
lenStr equ 58 ;5 + 53
;для цикла
len equ 6
;доп текст
enterS db 0ah,'$'
nofound db 'Not found', '$'

tableAb db 'ATCSE', 'faculty of automatic telec., comp. science and engin.'
        db 'REF  ', 'radio engineering faculty                            '
        db 'FEM  ', 'faculty of economics and management                  '
        db 'IT   ', 'information technology                               '
        db 'NCS  ', 'networks and communication systems                   '
        db 'GTF  ', 'general technical faculty                            '
result db 53 dup(' '),'$'
.code
assume ds:@data, es:@data

;главная
main:
    mov ax, @data
    mov ds, ax
    mov es, ax
    ;ввод с клавиатуры
    mov ah, 0Ah
    lea dx, NAMEPAR
    int 21h
	xor bx, bx
	mov bl, actlen
    mov namefld[bx],20h ;убираем enter как знак
    ;переход на новую строку
    mov ah, 09h
    lea dx, enterS
    int 21h
    ;поиск аббревиатуры
    dialoc len, tableAb, NAMEFLD, found, lenStr
    ;вывод на экран
    output nofound, lenStr, tableAb, result
	mov ax, 4c00h
	int 21h
end main