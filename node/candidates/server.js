'use strict';

const express = require('express');
const app = express();
app.use(express.json());

// constant reference to array from jsons
const database = new Array();

app.post('/candidates', function (req, res) {
    //verify if body is empty
    if (Object.keys(req.body).length === 0) {
        res.status(400)
        res.send('Candidate data not sent!')
        return
    }
    database.push(req.body)
    res.status(201)
    res.send('Candidate saved in memory database')
});

app.get('/candidates/search', function (req, res) {
    //verify if skills is being passed in request
    if (req.query.skills === '' || req.query.skills === undefined) {
        res.status(400)
        res.send('No skills in the request')
        return
    }
    //there is any candidate in database?
    if (database.length === 0) {
        res.status(404)
        res.send('There are no candidates in database yet!')
        return
    }
    //save skills into an array
    let skillsRequested = req.query.skills.split(',')
    //best candidate so far
    let bestCandidate
    let numberOfMatchingSkills = 0
    //get best candidate
    database.forEach(candidate => {
        let skillsMatchedFromCurrentCandidate = 0
        //see how many skills current candidate has
        for (let i = 0; i < skillsRequested.length; i++) {
            if (candidate.skills.includes(skillsRequested[i]))
                skillsMatchedFromCurrentCandidate++
        }
        //update best candidate so far
        if (skillsMatchedFromCurrentCandidate > numberOfMatchingSkills){
            bestCandidate = candidate
            numberOfMatchingSkills = skillsMatchedFromCurrentCandidate
        }
    });
    //there is a candidate that match any skills?
    if (!(bestCandidate === undefined)) {
        res.status(200)
        res.setHeader('Content-Type', 'application/json')
        res.send(bestCandidate)
    } else {
        res.status(404)
        res.send('No suitable candidate found!')
        return
    }
});

app.listen(process.env.HTTP_PORT || 3000);
