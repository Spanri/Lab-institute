
"use strict"
// const path = require('path');
const app = require('express')();
const http = require('http').Server(app);
const io   = require('socket.io')(http);
const spawn = require('child_process').spawn;

var sens = [];
var all = [];
var k = 0;
var speed = [];
var sen = [];
var id = [];

io.on('connection', (socket) => {
  console.log("Connect to client");

  var proxy = function(proc){
    let g = (sens[proc]/all[proc])*100;
    g = g<15 ? 15 : (g<31 ? 31 : (g<71 ? 71 : 100) );
    socket.emit('change', sens[proc], proc, g);
  }

  socket.on('opros',(proc)=>{
    for(let i=0;i<proc;i++) proxy(i);
  })
  
  socket.on('chan',async(proc)=>{
    sens[proc]+=50;
    await proxy(proc);
  });

  socket.on('addStart',async()=>{
    for(let i = 0;i<k;i++) {
      clearInterval(id[i]);
      sen[i].kill();
    }
    sens.length = 0;
    all.length = 0;
    speed.length = 0;
    sen.length = 0;
    k=0;
  });

  var fun = function(proc) {
    id[proc] = setInterval(async () => {
      try {
        if (sens[proc] < 0) throw new Error('Whoops!'); 
        sens[proc]-=speed[proc];
      }
      catch (err) {
        sens[proc] = -1;
        console.log(err);
        clearInterval(id[proc]);
      }
    }, 1000);
  };

  socket.on('add',async (add,speed2)=>{
    let proc = k;
    sens[proc] = add;
    all[proc] = add;
    speed[proc] = speed2;
    sen[proc] = spawn(`cmd`,['/c',fun(proc)],{detached: true,shell: true});

    sen[proc].stdout.on('data', (data) => {
      console.log(`stdout: ${data}`);
    });
    sen[proc].stderr.on('data', (data) => {
      console.log(`stderr: ${data}`);
    });
    sen[proc].on('exit', function(code,signal) {
      console.log(`About to exit with code: ${code}, signal: ${signal}, proc: ${proc}`);
    });

    k++;
  })  

  socket.on('disconnect', function(){
    console.log('user disconnected');
  });
});

http.listen(3000, () => {
  console.log('Server listen port 3000');
});