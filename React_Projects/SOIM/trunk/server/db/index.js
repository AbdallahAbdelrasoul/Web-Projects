
const sql = require("mssql/msnodesqlv8");

const conn = new sql.ConnectionPool({
    database: "SystemOfIndividualsModar3at",
    server: "DESKTOP-ED20T4D",
    driver: "msnodesqlv8",
    requestTimeout: 25,
    connectionTimeout: 25,
    options: {

      trustedConnection: true
    }
  });

const connEst5dam = new sql.ConnectionPool({
    database: "est5dam_production",
    server: "DESKTOP-ED20T4D",
    driver: "msnodesqlv8",
    requestTimeout: 25,
    connectionTimeout: 25,
    options: {

      trustedConnection: true
    }
  });

async function getDBConnection(){
    if(!conn.connected){
        await conn.connect()
    }

    return conn
}

async function getEst5damDBConnection(){
  if(!connEst5dam.connected){
    await connEst5dam.connect()
  }

  return connEst5dam
}

async function execQuery(qs){
    let localConn = await getDBConnection()
    const result = await localConn.query(qs)
    return result.recordset
}

async function exec(qs){
    let localConn = await getDBConnection()
    const result = await localConn.query(qs)
    return result
}

async function execForEst5dam(qs){
    let localConn = await getEst5damDBConnection()
    const result = await localConn.query(qs)
    return result
}

module.exports = {
    execQuery: execQuery,
    execForEst5dam: execForEst5dam,
    exec: exec
}
