$(document).ready(function(){

    //Выставлять ширину ввода строки равной ширине окна
    let w = $(window).width();
    $("#input").css('width',w-30-16);
    window.onresize = function(e){
        let w = $(window).width();
        $("#input").css('width',w-30-16);
    }
    $("#ciphers input").click(function(){
        let w = $('body').width();
        $("#input").css('width',w-30-16);
    });
});