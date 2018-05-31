
"use strict";

var _regenerator = require('babel-runtime/regenerator');

var _regenerator2 = _interopRequireDefault(_regenerator);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _asyncToGenerator(fn) { return function () { var gen = fn.apply(this, arguments); return new Promise(function (resolve, reject) { function step(key, arg) { try { var info = gen[key](arg); var value = info.value; } catch (error) { reject(error); return; } if (info.done) { resolve(value); } else { return Promise.resolve(value).then(function (value) { step("next", value); }, function (err) { step("throw", err); }); } } return step("next"); }); }; }

var path = require('path');
var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var spawn = require('child_process').spawn;
var execFile = require('child_process').execFile;
var exec = require('child_process').exec;

var sens = [];
var all = [];
var k = 0;
var speed = [];
var sen = [];

io.on('connection', function (socket) {
  console.log("Connect to client");

  var proxy = function proxy(proc) {
    var g = sens[proc] / all[proc] * 100;
    g = g < 15 ? 15 : g < 31 ? 31 : g < 71 ? 71 : 100;
    socket.emit('change', sens[proc], proc, g);
  };

  socket.on('opros', function (proc) {
    // for(let i=0;i<sens.length;i++) {console.log(sens[i]);
    // console.log(k);
    // sen[i].stdin.setEncoding('utf8');
    // sen[i].stdin.write('HELLO WORLD');
    // sen[i].stdin.end();
    //}
    for (var i = 0; i < proc; i++) {
      proxy(i);
    }
  });

  socket.on('chan', function () {
    var _ref = _asyncToGenerator( /*#__PURE__*/_regenerator2.default.mark(function _callee(proc) {
      return _regenerator2.default.wrap(function _callee$(_context) {
        while (1) {
          switch (_context.prev = _context.next) {
            case 0:
              sens[proc] += 50;
              _context.next = 3;
              return proxy(proc);

            case 3:
            case 'end':
              return _context.stop();
          }
        }
      }, _callee, undefined);
    }));

    return function (_x) {
      return _ref.apply(this, arguments);
    };
  }());

  socket.on('addStart', function () {
    // console.log('start'+k);
    for (var i = 0; i < k; i++) {
      sen[i].kill();
      console.log(sen[i].pid);
      // process.kill(-sen[i].pid);
      // sen[i].pid[j]);
    }
    sens.length = 0;
    all.length = 0;
    speed.length = 0;
    sen.length = 0;
    k = 0;
  });

  var fun = function fun(proc) {
    var _this = this;

    var id = setInterval(_asyncToGenerator( /*#__PURE__*/_regenerator2.default.mark(function _callee2() {
      return _regenerator2.default.wrap(function _callee2$(_context2) {
        while (1) {
          switch (_context2.prev = _context2.next) {
            case 0:
              _context2.prev = 0;

              if (!(sens[proc] < 0)) {
                _context2.next = 3;
                break;
              }

              throw new Error('Whoops!');

            case 3:
              if (sens[proc] != NaN) sens[proc] -= speed[proc];
              _context2.next = 11;
              break;

            case 6:
              _context2.prev = 6;
              _context2.t0 = _context2['catch'](0);

              sens[proc] = -1;
              console.log(_context2.t0);
              clearInterval(id);

            case 11:
            case 'end':
              return _context2.stop();
          }
        }
      }, _callee2, _this, [[0, 6]]);
    })), 1000);
  };

  socket.on('add', function () {
    var _ref3 = _asyncToGenerator( /*#__PURE__*/_regenerator2.default.mark(function _callee3(add, speed2) {
      var proc;
      return _regenerator2.default.wrap(function _callee3$(_context3) {
        while (1) {
          switch (_context3.prev = _context3.next) {
            case 0:
              proc = k;
              // console.log('add '+k);

              sens[proc] = add;
              all[proc] = add;
              speed[proc] = speed2;
              // sen[proc] = execFile(`node`,fun(proc)],{detached: true,shell: true});
              sen[proc] = exec('bash -c', fun(proc));
              // sen[proc].stdout.on('data', (data) => {
              //   console.log(`stdout: ${data}`);
              // });
              // sen[proc].stderr.on('data', (data) => {
              //   console.log(`stderr: ${data}`);
              // });
              // sen[proc].on('exit', (code,signal) => {
              //   console.log(`About to exit with code: ${code}, signal: ${signal}, proc: ${proc}`);
              // });
              k++;

            case 6:
            case 'end':
              return _context3.stop();
          }
        }
      }, _callee3, undefined);
    }));

    return function (_x2, _x3) {
      return _ref3.apply(this, arguments);
    };
  }());

  socket.on('disconnect', function () {
    console.log('user disconnected');
  });
});

http.listen(3000, function () {
  console.log('Server listen port 3000');
});
