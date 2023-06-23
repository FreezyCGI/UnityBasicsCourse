const express = require('express');
const app = express();
const port = 3000;

app.use(express.json())

const pool = require('./pool.js');

app.get('/highscore/:username', async (req, res) => {

    let username = req.params.username;

    if(!username)
    {
        console.log("username not defined in req.params")
        res.status(400).send();
        return;
    }

    const result = await pool.query(
        'select points ' +
        'from Highscore ' +
        'where username = $1'
        , [username]);

    res.send(result.rows);
})

app.post('/highscore', async (req, res) => {

    let highscore = req.body.highscore;

    if(!highscore)
    {
        console.log("highscore not defined in req.body")
        res.status(400).send();
        return;
    }

    const result = await pool.query(`
        INSERT INTO Highscore (username, points) 
        VALUES ($1, $2)
        ON CONFLICT (username) DO UPDATE 
        SET points = $2; `
        ,
        [highscore.username, highscore.points]);

    res.json(result.rowCount);
})

app.listen(port, () => {
    console.log(`Example app listening on port ${port}`);
})