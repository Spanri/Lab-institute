
$(document).ready(function(){
    
    var tabl = {
        start: {}
    };

    $("#but").click(function(){
        let str = $('body').children('input')[0].value.split(' ');
        let nest, f, k, clas;

        
        tabl.start.value = str[0];
        $(`.s`).html(str[0]);

        for(let i=1;i<str.length;i++){
            let start = tabl.start;
            clas='';
            nest = 0, f = false;
            while(!f){
                if(Number(str[i]) <= Number(start.value)) k = '0';
                else k = '1';
                if(start[k] != undefined) {
                    nest++;
                    start = start[k];
                    clas += k;
                }
                else {
                    start[k] = {};
                    clas += k;
                    start[k].value = str[i];
                    f = true;
                    var css = {
                        "display":"grid",
                        "grid-template-rows":"50% 50%",
                        "grid-rows-start": "2",
                        "border": "1px solid black",
                        "margin": "8px",
                        "padding": "8px"
                    }
                    if(nest == 0){
                        $(`.s`).append(`<div class="${clas}"></div>`);
                        $(`.${clas}`).css(css);
                        $(`.${clas}`).html(str[i]);
                    }
                    else{
                        let clas2 = clas.substring(0, clas.length - 1);
                        $(`.${clas2}`).append(`<div class="${clas}"></div>`);
                        $(`.${clas}`).css(css);
                        $(`.${clas}`).html(str[i]);
                    }
                } 
            }
        }
    });

    $("#but2").click(function(){
        let str = $('body').children('input')[2].value;
        let f = false;
        let start = tabl.start;
        let res = '';
        let path = start.value + " ";
        while(!f && start!=undefined){
            if(Number(str) > Number(start.value)) {
                if(start[1]==undefined) start=start[0];
                else start = start[1];
                path += start.value + " ";
            }
            else if(Number(str) < Number(start.value)) {
                if(start[0]==undefined) start=start[1];
                else start = start[0];
                path += start.value + " ";
            }
            else{
                f = true;
                res = start.value;
                console.log(start.value);
                console.log('Путь '+path);
            }
        }
        if(res=='') console.log('Не найдено');
    });
});