const express = require('express');

var route = require('./route');
var app = express();
var mongoose = require('mongoose');


const url = 'mongodb://localhost/platformer2d';

mongoose.connect(url).then(
  ()=>{console.log("connected")},
  err =>{console.log("err",err);}
);

app.use('/', route);



// Listen to the App Engine-specified port, or 8080 otherwise
const PORT = process.env.PORT || 8080;
app.listen(PORT, () => {
  console.log(`Server listening on port ${PORT}...`);
});