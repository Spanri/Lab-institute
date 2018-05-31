model 	small
stack 	100h
.data
public output
outstr dw ?
g db '$'
f db 14h
.code
    Show proc
        aam 
        add ax, 3030h 
        mov dl, ah 
        mov dh, al 
        mov ah, 02 
        int 21h 
        mov dl, dh 
        int 21h
        ret
    Show endp
  
	output proc
        ;пролог
        push bp
		mov	bp, sp

        xor ax, ax
        mov	al,	[bp+4]  ;заносим в ax кол-во символов в строке
        
        call Show   

        ;восстановление сохраненных регистров
        mov		sp, bp
		pop		bp
        ret
    endp
end 



