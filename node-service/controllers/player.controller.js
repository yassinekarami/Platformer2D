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
}
// exports.post = function(req, res) {
   
//     var p = new player({ name: 'test', score: 100});
//     p.save(function (err) {
//         if(err) return HandleError(err);
//         else res.send("joueur ajoute");
//     });
// };

module.exports = {
    get,
    post,
};