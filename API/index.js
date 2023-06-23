const express = require('express');
const app = express();
const port = 3000;

const pool = require('./pool.js');

app.get('/', async (req, res) => {

    const result = await pool.query(
        'select username, points ' +
        'from Highscore'
    );

    res.send(result.rows);
})

app.listen(port, () => {
    console.log(`Example app listening on port ${port}`);
})