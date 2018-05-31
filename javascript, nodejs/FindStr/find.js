
$(document).ready(function () {

    $("#find").on('click', function () {
        let str = $("body").children('input')[0].value;
        let substr = $("body").children('input')[1].value;
        console.time('bad search');
        bad(str,substr);
        console.timeEnd('bad search');
        console.time('good search');        
        find(str,substr);
        console.timeEnd('good search');
    });

    function bad(str,substr){
        let i = -1, m = substr.length, n = str.length;
        do{
            i++;
            j = 0;
            while((j < m) && (str[i + j] == substr[j])) j++;
        }while((j != m) && (i < n-m));
        console.log(`str[${i}...${i+j-1}] = substr`);
    }

    function prefix(str) {
        var m = str.length, pi = new Array(0);
        for (let i = 1; i < m; i++) {
            pi.push(0);
            let j = pi[i - 1];
            while (j > 0 && str[i] != str[j]) {
                j = pi[j - 1];
            }
            if (str[i] == str[j]) {
                pi[i] = j + 1;
            } else {
                pi[i] = j;
            }
        }
        return pi;
    }

    function find(str,substr){
        let pi = prefix(substr + '#' + str);
        let m = str.length, n = substr.length;
        for (let i = 0; i < m; i++) {
            if (pi[n + 1 + i] == n) {
                console.log(`str[${i-n+1}...${i}] = substr`);
                break;
            }
        }
    }
        
});

// str = '456485445648544564854456485445648544564854456485445648544564854245648542';
// substr = '45648542';