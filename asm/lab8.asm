;Составьте программу, которая для введенных с 
;клавиатуры значений х1, х2 и х3 вычисляет
;y = x1/12 + x2/7 + x3/14
;и сохраняет y в памяти в 2-10 установленном формате

model small
stack 100h
.data
y dw ?
g db '$'
mas dw 3 dup('$')
mas2 db 0ch, 7h, 0eh ;12, 7, 14
;для ввода
NAMEPAR label byte
MAXLEN db 20
ACTLEN db ?
NAMEFLD db 10 dup(' ')
;для цикла
len equ 3
;доп строки для вывода
str1 db 'Input 3 number (with enter, ex. 12 07 14):', '$'
str3 db ', ', '$'
;для перехода на новую строку
enterS db 0ah,'$'
.code
    assume ds:@data, es:@data

split proc
    mov cx, len                     ;сколько раз повторять 
    xor si, si                      ;счетчик цикла
    mov bx, offset mas              ;начало массива
    mov di, bx                      ;di - адрес начала массива
    сycle:
        push cx

        mov ax, si                  ;теперь ax - смещение в строке
        push si

        mov bx, offset NAMEFLD      ;начало строки
	    add ax, bx	                ;начало строки + смещение в строке
        mov si, ax                  ;si - адрес начала namefld + уже прошедшая строка

        mov cx, 2                   ;длина слова (2)
        rep movsb                   ;из si в di cx раз, теперь в di - число

        pop si                      ;достаем si(номер в цикле), оно больше не понадобится внутри
        add si, 3
        ;add di, 2
        pop cx               
        loop сycle
    ret
split endp

invert proc
    xor si, si
    mov cx, 3
    change:
        mov bx, offset mas[si]
        mov al, bl
        mov ah, bh
        mov bl, ah
        mov bh, al
        mov mas[si], bx 

        add si, 2
        loop change
    ret
invert endp

sub30 proc
    mov cx, 6                   ;сколько раз повторять 
    xor si, si                  ;счетчик цикла
    сycle2:
        sub mas[si], 30h
        add si, 1              
        loop сycle2
sub30 endp

nextline proc
    mov ah, 09h
    lea dx, enterS
    int 21h
    ret
nextline endp

calc proc
    mov y, 0h
    mov cx, len                 ;сколько раз повторять 
    xor si, si                  ;счетчик цикла
    xor di, di
    сycle3:
        ;делим число
        mov ax, mas[si]     ;в ax неупакованное число из массива
        mov bl, mas2[di]    ;обычное число
        aad
        div bl              ;в al - неупакованное число

        mov ah, 0h

        ;прибавляем поделенное число к результату
        mov bx, ax
        mov ax, y
        add ax, bx
        aaa
        mov y, ax

        add si, 2
        add di, 1              
        loop сycle3
    ret
calc endp

start:
    mov ax, @data
    mov ds, ax
    mov es, ax  

    ;вывод в консоль приглашения к вводу
    mov ah, 09h
    lea dx, str1
    int 21h

    ;на след строку
    call nextline

    ;считывать строку
    mov ah, 0Ah
    lea dx, NAMEPAR
    int 21h
	xor bx, bx
	mov bl, ACTLEN          ;в bl кладем длину
    mov NAMEFLD[bx],20h     ;убираем enter как знак

    ;разделить строку на массив
    call split
    ;перевести в формат неупакованного bcd
    ;в памяти 12 будет как 01 02 (+ в памяти всё в 16ричном коде)
    call sub30
    ;инвертируем числа
    call invert
    ;вычисление выражения
    call calc 

    ;превратить y в число для вывода
    ;поменять цифры в числе местами
    mov ax, y
    mov bl, al
    mov bh, ah
    mov al, bh
    mov ah, bl
    ;получили результат в ax, корректируем
    aaa
    ;заносим рез-т в y и превращаем в код для вывода
    mov y, ax
    adc y, 3030h

    ;вывод на экран значения
    mov ah, 09h
    lea dx, y
    int 21h
    
    mov ax, 4c00h
    int 21h
end start