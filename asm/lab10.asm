;Отсортировать таблицу по аббревиатуре (по возрастанию)

model small
stack 100h
.data
;кол-во символов в строке
lenStr equ 58 ;5 + 53
;для цикла
len equ 6
;доп текст
tempstr db 58 dup(?), '$'
enterS db 0ah,'$'
tableAb db 'ATCSE', 'faculty of automatic telec., comp. science and engin.'
        db 'REF  ', 'radio engineering faculty                            '
        db 'FEM  ', 'faculty of economics and management                  '
        db 'IT   ', 'information technology                               '
        db 'NCS  ', 'networks and communication systems                   '
        db 'GTF  ', 'general technical faculty                            '
.code
assume ds:@data, es:@data

change proc
    add si, cx  ;добавляем остаток
    sub si, 5   ;идем назад на начало
    
    add di, cx
    sub di, 5

    mov cx, lenStr
    push di
    mov di, offset tempstr
    rep movsb     ;заносим первый элемент в di из si
    pop di

    sub si, lenStr      ;возвращаемся на начало строки в первом элементе
    mov cx, lenStr      ;для меняния местами
    xchg si, di         ;меняем si и di, работаем с di (второй элемент)
    rep movsb           ;теперь в di - второй элемент, а первый в temstr
    xchg si, di         ;обратно, будем работать с si

    sub si, lenStr      ;на начало первого элемента снова
    sub di, lenStr
    mov cx, lenStr      ;для меняния местами снова

    push si
    mov si, offset tempstr
    rep movsb           ;первый элемент переносится во второй
    pop si

    sub di, lenStr
    ret
change endp

sort proc
    mov cx, len          
    mov si, offset tableAb  ;берем начало таблицы
    cld
    l1:
        mov di, si
        push cx         ;стек для сохранения индекса l1 (внешнего)
        dec cx          ;уменьшить на 1
        jcxz ex         ;конец, если на конце строки  
        l2:
            add di, lenStr
            push cx
            mov cx, 5   ;сколько сравнивать раз
            
            repe cmpsb  ;идем, пока равны
            je eqv      ;если всё равно, идем на метку
            dec si      ;вернуться, чтобы еще раз сравнить
            dec di

            lodsb       ;считываем в al из si
            mov ah, al  ;кладем в ah, ибо al еще понадобится
            xchg si, di ;меняем местами, ибо нам теперь нужен di в лице si
            lodsb
            xchg si, di ;обратно меняем

            cmp ah, al  ;сравниваем i и i+1 (символ, на котором вывалилось сравнение)
            jle lower   ;если меньше, идем на метку и не меняем ничего
            call change
            jmp next
            lower:
                add si, cx      ;сх уменьшается в cmp, поэтому остаток добавляем
                add di, cx      ;и в eqv вычитаем 5 (типа 3 прошло + 2 - 5)
            eqv:     
                sub si, 5       ;переход на первый элемент снова
                sub di, 5
                ;add di, lenStr      ;переход на новый второй элемент
            next:
                pop cx
            loop l2
        add si, lenStr
        pop cx
        loop l1
    ex:		
        ret
sort endp

nextline proc
    mov ah, 09h
    lea dx, enterS
    int 21h
    ret
nextline endp

;процедура вывода на экран
output proc
    mov cx, 6
    call nextline
    mov si, offset tableAb  ;для movsb(откуда заносим)
    m:
        mov di, offset tempstr  ;для movsb (куда заносим)
        push cx
        mov cx, lenStr  ;для считывания одной строки
        rep movsb       ;заносим в di(temstr) из si(tableAb) (cx раз - 58)
        pop cx
        ;вывод
        mov ah, 09h
        lea dx, tempstr
        int 21h
        call nextline
        loop m
    ret
output endp

;главная
main:
    mov ax, @data
    mov ds, ax
    mov es, ax
    ;сортировка
    call sort
    ;вывод на экран
    call output
	mov ax, 4c00h
	int 21h
end main