const express = require('express');
const mysql = require('mysql2');
const app = express();

app.use(express.json());

const database = mysql.createConnection({
    host: "127.0.0.1",
    user: "root",
    password: "",
    database: "securitygamedb",
})

app.get('/Scenarios', (req, res) => {
    const sql = `SELECT ScenarioID, Scenario, Answer, Incorrect1, Incorrect2, Incorrect3 FROM scenarios`;
    console.log("executing SQL:", sql);
    database.query(sql, (err, results) => {
        if(err) {
        console.error("Error: ", err);
        return res.status(500).json({message: "Server error, please try again later"})   
        }

        res.json(results);
    });


});

const port = 5000;
app.listen(port, () => console.log("Server Ready"));