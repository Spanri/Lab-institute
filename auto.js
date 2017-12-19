
//create the ability to enter data into console
const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

//input str
rl.question('Input str ', (data) => {
    H(data);
    rl.close();
});

//finite-state-machine, conditions
var cond = '';

function H(str){
    if(!str) console.log(cond);
    else if(str[0] == '_') {
        cond += 'H > ';
        B(str.slice(1));
    }
    else console.log('Str is not belong to this grammar');
    return;
}

function B(str){
    if(!str) console.log(cond);
    else if(str[0] == '0') {
        cond += 'B > ';
        B(str.slice(1));
    }
    else if(str[0] == '1') {
        cond += 'B > ';
        AB(str.slice(1));
    }
    else console.log('Str is not belong to this grammar');
    return;
}

function AB(str){
    if(!str) console.log(cond);
    else if(str[0] == '0') {
        cond += 'AB > ';
        str = str.slice(1);
        SAB(str);
    }
    else if(str[0] == '1') {
        cond += 'AB > ';
        str = str.slice(1);
        AB(str);
    }
    else console.log('Str is not belong to this grammar');
    return;
}

function SAB(str){
    if(!str) console.log(cond);
    else if(str[0] == '1' || str[0] == '0') {
        cond += 'SAB > ';
        str = str.slice(1);
        SAB(str);
    }
    else console.log('Str is not belong to this grammar');
    return;
}



