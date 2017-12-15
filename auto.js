
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
var cond2 = [];

function H(str){
    if(!str) {
        console.log(cond);
        for(i in cond2) console.log(cond2[i]);
    }
    else if(str[0] == '_') {
        // console.log(str[0]+" H");
        cond2.push(str[0]+" H");
        cond += 'H ';
        B(str.slice(1));
    }
    else console.log('Str is not belong to this grammar');
    return;
}

function B(str){
    if(!str) {
        console.log(cond);
        for(i in cond2) console.log(cond2[i]);
    }
    else if(str[0] == '0') {
        // console.log(str[0]+" B");
        cond2.push(str[0]+" B");
        cond += 'B ';
        B(str.slice(1));
    }
    else if(str[0] == '1') {
        // console.log(str[0]+" B");
        cond2.push(str[0]+" B");
        cond += 'B ';
        AB(str.slice(1));
    }
    else console.log('Str is not belong to this grammar');
    return;
}

function AB(str){
    if(!str) {
        console.log(cond);
        for(i in cond2) console.log(cond2[i]);
    }
    else if(str[0] == '0') {
        // console.log(str[0]+" AB");
        cond2.push(str[0]+" AB");
        cond += 'AB ';
        str = str.slice(1);
        SAB(str);
    }
    else if(str[0] == '1') {
        // console.log(str[0]+" AB");
        cond2.push(str[0]+" AB");
        cond += 'AB ';
        str = str.slice(1);
        AB(str);
    }
    else console.log('Str is not belong to this grammar');
    return;
}

function SAB(str){
    if(!str) {
        console.log(cond);
        for(i in cond2) console.log(cond2[i]);
    }
    else if(str[0] == '1' || str[0] == '0') {
        // console.log(str[0]+" SAB");
        cond2.push(str[0]+" SAB");
        cond += 'SAB ';
        str = str.slice(1);
        SAB(str);
    }
    else console.log('Str is not belong to this grammar');
    return;
}



