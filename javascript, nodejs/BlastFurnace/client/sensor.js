
$(document).ready(function () {

    $('#add').draggable({addClass:false});
    $(document).on("mouseover",".sensor", function() {
        $(this).draggable({containment:"parent",addClass:false});
    });

    var socket = io.connect('http://localhost:3000');
    
    socket.on('change',(serverData,i,k)=>{
        if (serverData == -1) serverData = 'Crash';
        let p = $("#i").children()[i];
        p.querySelector('.senp').innerHTML = serverData;
        if(k==100) p.style.borderColor = 'green';
        else if(k==71) p.style.borderColor = 'yellow';
        else if(k==31 || k==15) p.style.borderColor = 'red';
        if(k==15 && serverData!='Crash') $("#err").append(`<div class="error">Warning in sensor №${i+1}!</div>`);
        p.style.transition = 'border-color 0.7s ease-out';
    });

    $(document).on("click",".error",function(){
        $(this).css('display','none');
    });

    $('#plus').click(()=>{
        $("#add .valu").append('<input type="text">');
        $("#add .speed").append('<input type="text" value=1>');
    });

    $(document).on("click",".senb",function(){
        let p = $(this).siblings('.senp').text();
        let index = $( ".senb" ).index( this );
        if (p != 'Crash') socket.emit('chan',index);
    });

    $('#create').click(()=>{
        $('#add').css('display','none');
        var valu = $('#add .valu input');
        var speed = $('#add .speed input');
        console.log('prestart');
        socket.emit('addStart');
        console.log('start');
        for (var i = 0; i < valu.length; i++) {
            console.log('add');
            socket.emit('add', valu[i].value, speed[i].value);
            var tmpl = document.getElementById("tmpl").content.cloneNode(true).children[0];
            tmpl.querySelector(".senp").innerHTML = valu[i].value;
            $("#i").append(tmpl);
        }
        // await socket.emit('end');
        // console.log('end');
        setInterval(()=>{
            console.log('opros');
            socket.emit('opros',$('.sensor').length);
        },1000);
           
        
    });

    socket.on('disconnect', ()=> {
        console.log(`The ${socket.id} has disconnected!`);
    });
});
