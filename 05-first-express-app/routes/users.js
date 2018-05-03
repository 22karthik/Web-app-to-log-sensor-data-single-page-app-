var express = require('express');
var router = express.Router();
var util = require("util");
var fs = require("fs");
var path = require('path');
var url = require('url');

/* GET users listing. */
router.get('/', function(req, res, next) {
    var db = req.con;
    var data = "";
    db.query('SELECT * FROM log_lora',function(err,rows){
        //if(err) throw err;

        // console.log('Data received from Db:\n');
        console.log(rows);
        var data = rows;
        console.log(data);
        res.render('userIndex', { title: 'User Information', dataGet: data });
    });
});

router.get('/index', function(req, res, next) {
    var db = req.con;
    var data = "";
    db.query('SELECT * FROM log_lora',function(err,rows){
        //if(err) throw err;

        // console.log('Data received from Db:\n');
        console.log(rows);
        var data = rows;
        console.log(data);
        /*res.render('userIndex', { title: 'User Information', dataGet: data });*/
    });
});


module.exports = router;
