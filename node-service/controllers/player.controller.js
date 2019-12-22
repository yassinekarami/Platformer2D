var Player = require('../models/player.model');
var mongoose = require('mongoose');


function post(req, res) {
    player = new Player({
        _id: new mongoose.Types.ObjectId(),
        name: req.body.name,
        score: req.body.score
    });
    player.save().then(res => {
        console.log(res)
    }).catch(err => console.log(err));
};

function get(req, res) {
    Player.find(function(err, players) {
        if(err) res.send(err);
        res.json(players);
    });
};


module.exports = {
    get,
    post
};