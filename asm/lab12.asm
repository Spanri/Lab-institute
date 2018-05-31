;Составьте программу, которая подсчитывает
;количество символов в строке (строка может 
;содержать не более 99 символов и ограничена
;символом $) и выводит полученные значения на
;экран. Процедуру вывода результата подсчета
;на экран оформить в виде отдельного модуля.
;Передачу данных в модуль организовать 
;через стек.

model small
stack 100h
extrn output: near
.data
strlen db 'There are exactly 32 characters.', '$'
.code
assume ds:@data, es:@data
sum proc
    lea si, strlen   ;адрес начала строки

    mov di, si   ;сюда запишется адрес символа $
	mov	cx, 100h
	mov	al, '$'
	repne scasb

	sub	di, si          
	dec	di        ;перед символом $

    ret 
sum endp

;главная
main:
    mov ax, @data
    mov ds, ax
    mov es, ax

    ;подсчет символов в строке
    ;результат в 16ой форме, если 20 символов, то в di - 14
    call sum

    push di ;2 байта

    ;вывод на экран
    call output

	mov ax, 4c00h
	int 21h
end main
    include lab12-2.asm
end