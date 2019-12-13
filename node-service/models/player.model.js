const mongoose = require('mongoose');


let playerSchema = mongoose.Schema({
    _id: mongoose.Schema.Types.ObjectId,
    name: String,
    score: Number
});

module.exports = mongoose.model('Player', playerSchema);
