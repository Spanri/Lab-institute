
//Выполнять код, когда загрузится страница
$(document).ready(function(){

    //Переменные, содержащие информацию о коде/шифре
    let info = [
        "Kаждая буква заменяется на следующую за ней в алфавите. Так, A заменяется на B, B на C, и т.д. «ROT1» значит «ROTate 1 letter forward through the alphabet» (англ. «сдвиньте алфавит на одну букву вперед»). ",
        "В транспозирующих шифрах буквы переставляются по заранее определенному правилу. Например, если каждое слово пишется задом наперед, то из «all the better to see you with» получается «lla eht retteb ot ees uoy htiw». Другой пример — менять местами каждые две буквы. Таким образом, предыдущее сообщение станет «la tl eh eb tt re ot es ye uo iw ht». Подобные шифры использовались в Первую Мировую и Американскую Гражданскую Войну, чтобы посылать важные сообщения. Сложные ключи могут сделать такой шифр довольно сложным на первый взгляд, но многие сообщения, закодированные подобным образом, могут быть расшифрованы простым перебором ключей на компьютере. ",
        "В азбуке Морзе каждая буква алфавита, все цифры и наиболее важные знаки препинания имеют свой код, состоящий из череды коротких и длинных сигналов, часто называемых «точками и тире». Так, A — это «•–», B — «–•••», и т.д. В отличие от большинства шифров, азбука Морзе используется не для затруднения чтения сообщений, а наоборот, для облегчения их передачи (с помощью телеграфа). Длинные и короткие сигналы посылаются с помощью включения и выключения электрического тока. Телеграф и азбука Морзе навсегда изменили мир, сделав возможной молниеносную передачу информации между разными странами, а также сильно повлияли на стратегию ведения войны, ведь теперь можно было можно осуществлять почти мгновенную коммуникацию между войсками.",
        "Шифр простой подстановки, где каждая буква заменяется своим порядковым номером в алфавите.",
        "RSA (аббревиатура от фамилий Rivest, Shamir и Adleman) — криптографический алгоритм с открытым ключом, основывающийся на вычислительной сложности задачи факторизации больших целых чисел. Криптосистема RSA стала первой системой, пригодной и для шифрования, и для цифровой подписи."
    ];
    let img = [
        "",
        "",
        "https://cdn.tproger.ru/wp-content/uploads/2015/11/morsecodeletters-1024x566.jpg",
        "",
        ""
    ];

    //Обработчик события нажатия на кнопку
    $("#ciphers input").click(function(){
        let index = $(this).index();
        let str = $("body input[type='text']").val();
        let result;
        switch(index){
            case 0: result = rot1(str); break;
            case 1: result = tran(str); break;
            case 2: result = morze(str); break;
            case 3: result = A1Z26(str); break;
            case 4: result = RSA(str); break;
            default: break;
        }
        $("#info").css('display','block');
        $("#info").html(info[index]);
        $("#result").html("Результат: " + result);
        $("#img").css('background-image',`url('${img[index]}')`).css('background-size','100% 100%');
    });

    //Функции - алгоритмы
    
    function rot1(str){
        for (let i = 0, m = str.length; i < m; i++) {
            let symb = String.fromCharCode(str.charCodeAt(i)+3);
            str = str.substr(0,i) + symb + str.substr(i+1);
        }
        return str;
    }

    function tran(str){
        for (let i = 0, m = str.length; i < m; i+=2) {
            if(str[i+2]) str = str.substr(0,i) + str[i+1] + str[i] + str.substr(i+2);
        }
        return str;
    }

    function morze(str){
        let alphabet = {
            'a': '*-',
            'b': '-***',
            'c': '-*-*',
            'd': '-**',
            'e': '*',
            'f': '**-*',
            'g': '--*',
            'h': '****',
            'i': '**',
            'j': '*---',
            'k': '-*-',
            'l': '*-**',
            'm': '--',
            'n': '-*',
            'o': '---',
            'p': '*--*',
            'q': '--*-',
            'r': '*-*',
            's': '***',
            't': '-',
            'u': '**-',
            'v': '***-',
            'w': '*--',
            'x': '-**-',
            'y': '-*--',
            'z': '--**'  
        }
        console.clear();
        for(let i = 0;str[i]!=undefined;) {
            let symb = str[i].toLowerCase();
            str = str.substr(0,i) + alphabet[`${symb}`] + str.substr(i+1);
            console.log(symb+" "+alphabet[`${symb}`]);
            i+=alphabet[`${symb}`].length;
        }
        return str;
    }

    function vizhener(str){
        for (let i = 0, m = str.length; i < m; i++) {

        }
        return str+" (Кодовое слово - mtuci)";
    }

    function A1Z26(str){
        let str2 = '';
        for (let i = 0, m = str.length; i < m; i++)
            str2 += (str.charCodeAt(i)-96);
        return str2;
    }

    function RSA(str){
        function bpowMod(x, n, m)
        {
            let count = 1;
            if (n == 0) return 1;
            while (n != 0)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                    x *= x;
                    x %= m;
                }
                else
                {
                    n--;
                    count *= x;
                    count %= m;
                }
            }
            return count % m;
        }
        function findSimple(phi)
        {
            let A = [], count = 0;
            for (let blin = 0; blin < phi; blin++)
                A[blin] = true;
            for (let i = 2; i < Math.sqrt(phi) + 1; ++i)
            {
                if (A[i])
                {
                    count++;
                    for (let j = i * i; j < phi; j += i)
                    {
                        A[j] = false;
                    }
                    if (phi % i == 0)
                    {
                        A[i] = false;
                        count--;
                    }
                }
            }
            let mas = [], index = 0;
            for(let i = 2; i < phi && index < count; i++)
            {
                if (A[i])
                {
                    mas[index] = i;
                    index++;
                }
            }
            return mas;
        }
        function algEuqlid(e, phi)
        {
            let n = phi, alpha = [], beta = [];
            alpha[0] = beta[1] = 1;
            alpha[1] = beta[0] = 0;
            let r, q, i = 2;
            for (; e != 0; i++)
            {
                r = phi % e;
                q = Math.floor(phi/e);
                alpha[i] = alpha[i - 2] - q * alpha[i - 1];
                beta[i] = beta[i - 2] - q * beta[i - 1];
                phi = e;
                e = r;
            }
            if (beta[i - 2] < 0)
                return beta[i - 2] + n;
            else
                return beta[i - 2];
        }
        function EncryptAndDecryptDisMess(Mess, e, n)
        {
            let mas = [];
            for (let i = 0, length = Mess.length; i < length; i++){
                mas[i] = bpowMod(Mess[i], e, n);
            }
            return mas;
        }
        let p = 47, q = 31, n = p * q;

        let Mess = [];
        for(let i=0;str[i]!=undefined;i++){
            Mess[i] = str.charCodeAt(i);
        }

        let phi = (p - 1) * (q - 1); //вычисление функции Эйлера
        let eMas = findSimple(phi); //запись в массив всех простых чисел от 1 до phi, взаимно простых с phi
        do
        {
            E = eMas[Math.floor(Math.random()*eMas.length)]; //выбор открытого ключа Боба
            d = algEuqlid(E, phi); //расширенный алгоритм Евклида для поиска закрытого ключа Боба
        } while (E == d); //контроль неравенства публичного и приватного ключей Боба
        do
        {
            eA = eMas[Math.floor(Math.random()*eMas.length)]; //выбор открытого ключа Алисы
            dA = algEuqlid(eA, phi); //расширенный алгоритм Евклида для поиска закрытого ключа Алисы
        } while (eA == dA);
        let res = EncryptAndDecryptDisMess(Mess, E, n);
        let res2 = EncryptAndDecryptDisMess(res, d, n);
        let res3 = '';
        for(let i=0;i<res2.length;i++){
            res3 += String.fromCharCode(res2[i]);
        }
        console.clear();
        console.log("Расшифровка: "+res3);
        return res;
    }

});