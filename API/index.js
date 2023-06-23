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

        if(result.rowCount <= 0)
        {
            res.status(404).send();
            return;
        }


    res.send(result.rows[0]);
})

app.post('/highscore', async (req, res) => {

    console.log(req.body)
    let highscore = req.body;

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