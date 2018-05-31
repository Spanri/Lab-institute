;поиск аббревиатуры
dialoc macro len, tableAb, NAMEFLD, found, lenStr
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
    jmp ex1        
found:	
    pop si
    pop cx
    mov bx, 6
    sub bx, cx
ex1:		
endm

;процедура вывода на экран
output macro nofound, lenStr, tableAb, result
    cmp bx, -1
    jne m       ;если не равно -1, то идем по метке, иначе выводим Не найдено
    mov ah, 09h
    lea dx, nofound
    int 21h
    jmp ex2
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
ex2:
endm