function parseDateFromString(date_str){
    date_str = date_str.split(' ')[0]
    if(date_str == null || date_str == "") return false 
    let isYMD = date_str.split('/')[0].length == 4
    date_str = date_str.replaceAll('/', '-')

    if(!isYMD){ // DD-MM-YY
        date_str = date_str.split('-').reverse().join('-')
    }
    let d = new Date(date_str)
    if(d.toString() == 'Invalid Date'){
        return false
    }
    return d
}

module.exports = {
    parseDateFromString: parseDateFromString
}