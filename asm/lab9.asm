;Задайте в памяти таблицу из 6ти элементов вида: (в программе есть)
;Составьте программу, которая вводит с клавиатуры
;аббревиатуру наименования факультета, находит
;в таблице полное название и выводит его на экран.

model small
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

;поиск аббревиатуры
dialoc proc
    xor ax, ax
    mov cx, len             
    mov si, offset tableAb
    xor bx, bx
    l1:
        push cx 
        push si      
        mov di, offset NAMEFLD      
        mov cx, 5          
        cld
        repe cmpsb        
        jz found        ;если найдено
        pop si
        add si, lenStr   
        pop cx	 
        loop l1
    mov bx, -1		
    jmp ex        
found:	
    pop si
    pop cx
    mov bx, 6
    mov bx, 6
    sub bx, cx
ex:		
	ret
dialoc endp

;процедура вывода на экран
output proc
    cmp bx, -1
    jne m       ;если не равно -1, то идем по метке, иначе выводим Не найдено
    mov ah, 09h
    lea dx, nofound
    int 21h
    ret
m:
	xor ax, ax
	mov al, bl      ;номер строки
	mov bl, lenStr
	mul bl          ;умножаем номер на кол-во символов в строке
	add al, 5       ;смещение
	mov bx, offset tableAb ;начало таблицы
	add ax, bx	    ;начало табл -> начало строки -> смещение в строке
    mov si, ax
	mov di, offset result
	mov cx, 53
	cld
	rep movsb ;сх раз перемещаем в result из таблицы
    mov ah, 09h
	lea dx, result
    int 21h
    ret
output endp

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
    call dialoc
    ;вывод на экран
    call output
	mov ax, 4c00h
	int 21h
end main