const express = require('express');

var route = require('./route');
var app = express();
var mongoose = require('mongoose');


const url = 'mongodb+srv://yassine:yassine@cluster-z7gp3.gcp.mongodb.net/test?retryWrites=true&w=majority';

mongoose.connect(url, {
  useMongoClient: true
});

app.use('/', route);



// Listen to the App Engine-specified port, or 8080 otherwise
const PORT = process.env.PORT || 8080;
app.listen(PORT, () => {
  console.log(`Server listening on port ${PORT}...`);
});