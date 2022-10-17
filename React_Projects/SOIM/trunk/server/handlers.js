const jwt = require('jsonwebtoken')
const db = require('./db')
const queries = require('./db/queries')
const helpers = require('./helpers')
var allperson


async function getUnits(req, res)  {
    const headers = {
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Max-Age': 2592000, // 30 days
      /** add other headers as per requirement */
    };

    const result = await db.execQuery(queries.getAllUnits);
    allperson = JSON.stringify(result);
    res.writeHead(200, headers); //write a response to the client
    res.end(allperson)
}

async function getSafInKhedmaByMilNo(req, res) {
  const headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Max-Age': 2592000, // 30 days
    /** add other headers as per requirement */
  };

    const q = queries.getSafZabetByMilNo.replace('{MIL_NO}', req.params.MIL_NO)
    const result = await db.execQuery(q);
    allperson = JSON.stringify(result);

  res.writeHead(200, headers); //write a response to the client
  res.end(allperson)
}

async function getAllAfro3(req, res) {
  const headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Max-Age': 2592000, // 30 days
    /** add other headers as per requirement */
  };

    const q = queries.getAllAfro3
    const result = await db.execQuery(q);
    allperson = JSON.stringify(result);

  res.writeHead(200, headers); //write a response to the client
  res.end(allperson)
}


async function addSafToSuggestedInNashra(req, res) {
  const headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Max-Age': 2592000, // 30 days
    /** add other headers as per requirement */
  };

  const q = queries.addSafToSuggestedNashra.replace('{MIL_NO}', req.params.MIL_NO)
    
  const result = await db.exec(q);

  res.writeHead(200, headers); //write a response to the client
  res.end('success')
}


async function setPersonTmam(req, res) {
  const headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Max-Age': 2592000, // 30 days
    /** add other headers as per requirement */
  };

  const q = queries.setTamamByMilNo.replace('{MIL_NO}', req.params.MIL_NO).replace('{TMAM}', req.params.TMAM)
    
  const result = await db.exec(q);

  res.writeHead(200, headers); //write a response to the client
  res.end('success')
}

async function removeSafToSuggestedInNashra(req, res) {
  const headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Max-Age': 2592000, // 30 days
    /** add other headers as per requirement */
  };

  const q = queries.removeSafToSuggestedNashra.replace('{MIL_NO}', req.params.MIL_NO)
    
  const result = await db.exec(q);

  res.writeHead(200, headers); //write a response to the client
  res.end('success')
}

async function getAllSafInKhedma(req, res) {
  const headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Max-Age': 2592000, // 30 days
    /** add other headers as per requirement */
  };

  const result = await db.execQuery(queries.getAllSafwithMinDetails);
  const data = []
  let milno = ''
  for (rec_idx in result){
    const rec = result[rec_idx]
    let idx = -1
    if(rec['MIL_NO'] == milno){
      idx = data.length - 1
      if(rec['TANFEZ_DATE'] && helpers.parseDateFromString(rec['TANFEZ_DATE'])){
        data[idx]['units_history'].push({
          'from': rec['UNIT_FROM'],
          't_from': rec['TAMARKOZ_FROM'],
          'to': rec['UNIT_TO'],
          't_to': rec['TAMARKOZ_TO'],
          'nashra_date': helpers.parseDateFromString(rec['NASHRA_DATE']),
          'tanfez_date': helpers.parseDateFromString(rec['TANFEZ_DATE'])
        })
      }

    } else {
      /*
      let prev_idx = data.length - 1
      if(data.length != 0 && data[prev_idx]['units_history'].length != 0){
        let arr = []
        data[prev_idx]['units_history'] = data[prev_idx]['units_history'].sort(function(a,b){
          return a['nashra_date'] > b['nashra_date']
        })
      }
      */

      milno = rec['MIL_NO']
      data.push(rec)
      idx = data.length - 1
      data[idx]['units_history'] = []
      if(rec['TANFEZ_DATE'] && helpers.parseDateFromString(rec['TANFEZ_DATE'])){
        data[idx]['units_history'].push({
          'from': rec['UNIT_FROM'],
          't_from': rec['TAMARKOZ_FROM'],
          'to': rec['UNIT_TO'],
          't_to': rec['TAMARKOZ_TO'],
          'nashra_date': helpers.parseDateFromString(rec['NASHRA_DATE']),
          'tanfez_date': helpers.parseDateFromString(rec['TANFEZ_DATE'])
          })
      }

    }
  
  }
  allperson = JSON.stringify(data);
  res.writeHead(200, headers); //write a response to the client
  res.end(allperson)
}

async function getAllSafInKhedmaByUnitCode(req, res) {
  const headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Max-Age': 2592000, // 30 days
    /** add other headers as per requirement */
  };

    const q = queries.getAllPersonsInKhedmaWithMainDataOnlyByUnitCode.replace('{UNIT_CODE}', req.params.unit_code)
    const result = await db.execQuery(q);
    allperson = JSON.stringify(result);
  
  res.writeHead(200, headers); //write a response to the client
  res.end(allperson)
}

async function getAllSoldiersInKhedmaByUnitCode(req, res) {
  const headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Max-Age': 2592000, // 30 days
    /** add other headers as per requirement */
  };

  const q = queries.getAllSoldiersInKhedmaWithMainDataOnlyByUnitCode.replace('{UNIT_CODE}', req.params.unit_code)
  const result = await db.execQuery(q);
  allperson = JSON.stringify(result);
  
  res.writeHead(200, headers); //write a response to the client
  res.end(allperson)
}

async function signin(req, res)  {
  const query = 'SELECT * FROM ACCOUNT WHERE MIL_NO=\'' + req.body.username + '\' AND PASSWORD=\'' + req.body.password + '\''

  const account = await db.execQuery(query);
  console.log(account.length)

  if(account.length != 1){
    res.status(401)
    res.sendFile( __dirname + '/web/auth/signin.html')
  } else {
    let token = jwt.sign(account, 'mysecret', {algorithm: 'RS256'})
    res.setHeader('token', token)
    res.sendFile( __dirname + '/web/auth/waiting.html')

  }

}

async function replaceExcelDataToIDs(req, res) {
  const headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Max-Age': 2592000, // 30 days
    /** add other headers as per requirement */
  };
  const rows = req.body
  console.log(rows)

  const failed_records = []

  
    for(idx in rows){
      const rec = rows[idx]
      let q = queries.getTa5sosIDByName.replace('{T_NAME}', rec['التخصيص'])
      let data = await db.execForEst5dam(q);
      if(data.length >= 1){
        rows[idx]['التخصيص'] = data[0]['CODE']
      }
      else {
        failed_records.push({idx: idx, column: 'التخصيص'})
      }

      q = queries.getMGEst5damCodeByName.replace('{MGE_NAME}', rec['مج الإستخدام'])
      data = await db.execForEst5dam(q);
      if(data.length >= 1){
        rows[idx]['مج الإستخدام'] = data[0]['CODE']
      }
      else {
        failed_records.push({idx: idx, column: 'مج الإستخدام'})
      }

      q = queries.getTypeCodeByName.replace('{TTC_NAME}', rec['النوع'])
      data = await db.execForEst5dam(q);
      if(data.length >= 1){
        rows[idx]['النوع'] = data[0]['CODE']
      }
      else {
        failed_records.push({idx: idx, column: 'النوع'})
      }

      q = queries.getTypeCodeByName.replace('{U_NAME}', rec['الوحدة'])
      data = await db.execForEst5dam(q);
      if(data.length >= 1){
        rows[idx]['الوحدة'] = data[0]['CODE']
      }
      else {
        failed_records.push({idx: idx, column: 'الوحدة'})
      }

      q = queries.getTypeCodeByName.replace('{U_NAME}', rec['الوحدة الفرعية'])
      data = await db.execForEst5dam(q);
      if(data.length >= 1){
        rows[idx]['الوحدة الفرعية'] = data[0]['CODE']
      }
      else {
        failed_records.push({idx: idx, column: 'الوحدة الفرعية'})
      }
    }
  
  res.writeHead(200, headers); //write a response to the client
  res.end(JSON.stringify({failed_records: failed_records, data: rows}))
}

async function getSafUnitHistory(req, res) {
  const headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Max-Age': 2592000, // 30 days
    /** add other headers as per requirement */
  };

    const q = queries.getSafUnitHistory
    const result = await db.execQuery(q);
    allperson = JSON.stringify(result);
  
  res.writeHead(200, headers); //write a response to the client
  res.end(allperson)
}

module.exports = {
    getUnits: getUnits,
    signin: signin,
    getAllSoldiersInKhedmaByUnitCode: getAllSoldiersInKhedmaByUnitCode,
    getAllSafInKhedma: getAllSafInKhedma,
    addSafToSuggestedInNashra: addSafToSuggestedInNashra,
    removeSafToSuggestedInNashra: removeSafToSuggestedInNashra,
    getSafInKhedmaByMilNo: getSafInKhedmaByMilNo,
    getAllSafInKhedmaByUnitCode: getAllSafInKhedmaByUnitCode,
    getSafUnitHistory: getSafUnitHistory,
    replaceExcelDataToIDs: replaceExcelDataToIDs,
    getAllAfro3: getAllAfro3,
    setPersonTmam: setPersonTmam
}

/*
app.post('requests/signup', async(req, res) => {
  await conn.exec('CREATE SIGNUP_REQUESTS (USERNAME, MIL_NO, DEGREE) VALUES (' + req.params.id + ' )')

  res.end({})
})

app.get('requests/signup', async(req, res) => {
  let sn_requests = await conn.query('SELECT * FROM SIGNUP_REQUESTS')
  sn_requests = JSON.stringify(sn_requests.recordset);

  res.end(sn_requests)
})

app.post('requests/signup/approve', async(req, res) => {
   await conn.exec('UPDATE SIGNUP_REQUESTS SET APPROVED=1 WHERE MIL_NO=' + req.params.id)

  res.end({})
})

app.post('/signup', async(req, res) => {
  await conn.exec('CREATE ACCOUNTS (USERNAME, MIL_NO, PASSWORD, DEGREE) VALUES (' + req.params.id + ' )')

  res.end({})
})
app.post('requests/signup/approve', async(req, res) => {
  await conn.execQuery('UPDATE SIGNUP_REQUESTS SET APPROVED=1 WHERE MIL_NO=' + req.params.id)

 res.end({})
})
*/
