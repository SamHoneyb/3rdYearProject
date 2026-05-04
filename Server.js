const express = require('express');
const mysql = require('mysql2');
const app = express();

app.use(express.json());
//connects to the database
const database = mysql.createConnection({
    host: "127.0.0.1",
    user: "root",
    password: "",
    database: "securitygamedb",
})

//Gets all the scenarios from the database
app.get('/Scenarios', (req, res) => {
    const sql = `SELECT ScenarioID, Scenario, Answer, Incorrect1, Incorrect2, Incorrect3, Reason, Summary FROM scenarios`;
    console.log("executing SQL:", sql);
    database.query(sql, (err, results) => {
        if(err) {
        console.error("Error: ", err);
        return res.status(500).json({message: "Server error, please try again later"})   
        }

        res.json(results);
    });


});
//collected the scummaries from the database to populate the dropdown
app.get('/Summaries', (req, res) => {
    const sql = `SELECT ScenarioID, Summary FROM scenarios`;
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