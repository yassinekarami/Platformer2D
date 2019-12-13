var express = require('express');
var bodyParser = require('body-parser')
var jsonParser = bodyParser.json()
var router = express.Router();
const playerController = require('./controllers/player.controller');

router.get('/', (req, res) => {
    res.send('route!');
  });

router.get('/joueurs', playerController.get);
router.post('/joueurs', jsonParser, playerController.post);

module.exports = router;