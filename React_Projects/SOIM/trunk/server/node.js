const  express = require('express')
const bodyParser = require('body-parser')
const handlers = require('./handlers') 
const app = express()


app.use(bodyParser.urlencoded({extended: true}))
app.use(bodyParser.json())


app.get('/getunits',handlers.getUnits)
app.get('/getAllSaf', handlers.getAllSafInKhedma)
app.get('/getSaf/:MIL_NO', handlers.getSafInKhedmaByMilNo)
app.get('/nashra/suggest/:MIL_NO', handlers.addSafToSuggestedInNashra)
app.get('/nashra/remove/:MIL_NO', handlers.removeSafToSuggestedInNashra)
app.get('/setPersonTmam/:MIL_NO/:TMAM', handlers.setPersonTmam)

app.get('/getAllSaf/unit/:unit_code', handlers.getAllSafInKhedmaByUnitCode)
app.get('/getAllSoldiers/unit/:unit_code', handlers.getAllSoldiersInKhedmaByUnitCode)

app.get('/getSafUnitTransferHistory', handlers.getSafUnitHistory)

app.post('/replaceExcelDataToIDs', handlers.replaceExcelDataToIDs)
app.get('/allafro3', handlers.getAllAfro3)
app.post('/login', handlers.signin)
app.get('/atwagy', function(req, res){
    res.sendFile( __dirname + '/web/atwa.html')
})

app.get('/xlsx.full.min.js', function(req, res){
    res.sendFile( __dirname + '/web/xlsx.full.min.js')
})

app.get('/jszip.js', function(req, res){
    res.sendFile( __dirname + '/web/jszip.js')   
})

app.use(express.static('web'))


app.listen(8080)


 