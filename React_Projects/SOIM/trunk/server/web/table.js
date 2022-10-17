
var data;
var maindata;
var table;
var makeNashrafilter = false;

var count = 0;
var UIcounter = 0
var stop = false;

/////////////////// init /////////////////////////
function load() {
  openandclosefilter()
  getallunits();
  settextboxsvalue();
  var liselement = document.getElementsByClassName("windowsSize");
  for (let index = 0; index < liselement.length; index++) {
    const element = liselement[index];
    element.style.height = `${window.innerHeight}px`
  }
  table = document.getElementById("mainTable")
}
function settextboxsvalue() {
  var t = document.getElementsByClassName("DateTimePicker")
  var dnow = new Date(Date.now())
  t[0].value = `${dnow.getFullYear()}/7/1`
  t[1].value = `${dnow.getFullYear() + 1}/1/1`
}
function getallunits() {
  var xhttp = new XMLHttpRequest();
  console.log('sending http request ....................')
  xhttp.onreadystatechange = async function () {
    document.getElementById("loadingtext").style.display = "none";
    if (this.readyState == 4 && this.status == 200) {
      data = JSON.parse(this.responseText)
      setresultvalue(data.length)
      for (let index = 0; index < data.length; index++) {
        const element = data[index];
        element.TO_UNIT_DATE = dateTostring(element.TO_UNIT_DATE)
      }
    }
  };

  xhttp.open("GET", "http://localhost:8080/getunits", true);
  document.getElementById("loadingtext").style.display = "block"
  xhttp.send();

}
////////////////////////////////////////////



///////////////////// controllers ///////////////////////
var isfinshfade = true;
setInterval(() => {
  function rec() {
    if (stop || !isfinshfade) return;
    if (data == undefined) return;
    if (data.length <= count) return;
    var parent = table.parentElement;
    // if(date.UNIT_NAME)
    // if(data.GROUP_JOB_NAME)
    if (parent.scrollTop + parent.offsetHeight + 1000 < table.offsetHeight) {
      // var ch = document.getElementsByClassName("mytr")
      // for (let index = 0; index < ch.length; index++) {
      //   const uielement = ch[index];
      //   uielement.style.opacity = "1"
      //   isfinshfade = false
      //   setTimeout(() => isfinshfade = true, 200)
      // }
      return;
    }

    const element = data[count++];
    if (makeNashrafilter && !NashraFilter(element)) { rec(); return; }
    if (element.GROUP_JOB_NAME == undefined) { rec(); return; }
    //  if(!element.GROUP_JOB_NAME.includes("خازن")) { rec(); return; }
    setrecord(element)
  }
  rec()
}, 1)
var elements = []
function setrecord(element) {
  if (UIcounter == 0) {
    table.innerHTML += `  
    <th style="height: 50px;">
    <div style="min-width: 300px; display: flex; flex-direction: row;">
        <div class="sort" style="flex: 50px;"> <img src="logos/up_down.png" onclick="sortBtun(this)">
        </div>
        <p style="flex: 100%;">الاسم</p>
        <div class="parentXbutton" style="flex: 50px;">
            <div class="Xbutton"> <img src="logos/close.png" onclick="deleteButn(this)"> </div>
        </div>
    </div>
</th>
<th style="height: 50px;">
    <div style="min-width: 300px; display: flex; flex-direction: row;">
        <div class="sort" style="flex: 50px;"> <img src="logos/up_down.png" onclick="sortBtun(this)">
        </div>
        <p style="flex: 100%;">الوحدة الحالية</p>
        <div class="parentXbutton" style="flex: 50px;">
            <div class="Xbutton"> <img src="logos/close.png" onclick="deleteButn(this)"> </div>
        </div>
    </div>
</th>
<th style="height: 50px;">
    <div style="min-width: 300px; display: flex; flex-direction: row;">
        <div class="sort" style="flex: 50px;"> <img src="logos/up_down.png" onclick="sortBtun(this)">
        </div>
        <p style="flex: 100%;">تاريخ اخر تنقل</p>
        <div class="parentXbutton" style="flex: 50px;">
            <div class="Xbutton"> <img src="logos/close.png" onclick="deleteButn(this)"> </div>
        </div>
    </div>
</th>
<th style="height: 50px;">
    <div style="min-width: 300px; display: flex; flex-direction: row;">
        <div class="sort" style="flex: 50px;"> <img src="logos/up_down.png" onclick="sortBtun(this)">
        </div>
        <p style="flex: 100%;">الوظيفة</p>
        <div class="parentXbutton" style="flex: 50px;">
            <div class="Xbutton"> <img src="logos/close.png" onclick="deleteButn(this)"> </div>
        </div>
    </div>
</th>
`
  }
  var s = `
  <td>${element.PERSON_NAME}</td>
  <td>${element.UNIT_NAME}</td>
  <td>${dateTostring(element.TO_UNIT_DATE)}</td>
  <td>${element.GROUP_JOB_NAME}</td>
  `
  if (UIcounter++ % 2 == 0) s = `<tr class="mytr" > ${s} </tr>`
  else s = `<tr class="mytr" style="background-color: #dddddd;"> ${s} </tr>`
  // console.log(uielement)
  //  uielement.style.opacity = "1"
  // uielement.style.trans = "0"
  table.innerHTML += s


}
function NashraFilter(element) {
  var t = document.getElementsByClassName("DateTimePicker")
  var elementDate = element.TO_UNIT_DATE
  if (typeof (elementDate) == "string") {
    elementDate = stringtodate(element.TO_UNIT_DATE)
  }
  if (elementDate == undefined || elementDate == "") return false;

  var m = dateAfterNumM(elementDate, 60)
  if (element.GROUP_JOB_NAME == null) return false;
  if(element.GROUP_JOB_NAME.includes("خازن"))
    m = dateAfterNumM(elementDate, 24)
  if (stringtodate(t[0].value) < m && stringtodate(t[1].value) > m) {
    return true;
  }
  return false;

}
function OrderByName() {
  data = data.sort((a, b) => a.PERSON_NAME > b.PERSON_NAME ? 1 : -1)
  resettable();
}
function resettable() {
  table.innerHTML = "";
  UIcounter = 0;
  counter = 0;
}
function OrderByUnit() {
  data = data.sort((a, b) => a.UNIT_NAME > b.UNIT_NAME ? 1 : -1)
  resettable();

}
////////////////////////////////////////////

/////////////////// events methods /////////////////////////
function onmykeypress(event) {
  if (event.keyCode == 13)
    event.srcElement.blur()
}

function invalidationInputDate(v) {
  if (v.value.length == 0) return false;
  function ifwrong(mess) {
    v.value = "";
    return false;
  }
  var lis = v.value.split('/')
  if (lis.length != 3) ifwrong(1)

  if (isNaN(lis[0]) || isNaN(lis[1]) || isNaN(lis[2])) ifwrong(2)
  var testyear = new Date(Date.now()).getFullYear()
  if (Math.abs(Number(lis[0]) - testyear) > 100) ifwrong(3)

  if (lis[1] > 12 || lis[1] < 0) ifwrong(4)

  if (lis[2] > 31 || lis[2] < 0) ifwrong(5)
  return true;
}


function setNashraFilter() {
  makeNashrafilter = true;
  resettable();

  var logiccounter = 0;
  for (let index = 0; index < data.length; index++) {
    const element = data[index];
    if (NashraFilter(element)) logiccounter++;
  }
  setresultvalue(logiccounter)
}

function openandclosefilter() {

  if (document.getElementById("filterBox").style.transform == "translateX(-100%)")
    document.getElementById("filterBox").style.transform = "translateX(0%)";
  else
    document.getElementById("filterBox").style.transform = "translateX(-100%)";
}

//////////////////////////////////////////////////////////
/////////////////// date methods /////////////////////////

function stringtodate(vdate) {
  function ifwrong(mess) {
    return false;
  }
  if (vdate.length == 0) ifwrong(0)

  var lis = vdate.split('/')
  if (lis.length != 3) ifwrong(1)

  if (isNaN(lis[0]) || isNaN(lis[1]) || isNaN(lis[2])) ifwrong(2)
  var testyear = new Date(Date.now()).getFullYear()
  if (Math.abs(Number(lis[0]) - testyear) > 100) ifwrong(3)

  if (lis[1] > 12 || lis[1] < 0) ifwrong(4)

  if (lis[2] > 31 || lis[2] < 0) ifwrong(5)

  ///////////////////////////////////////////
  var date = vdate.split('/')
  var year = Number(date[0]);
  var month = Number(date[1]);
  var day = Number(date[2]);
  if (date[2] == undefined) return;

  if (date[2].length == 2) {
    year = Number(date[0]);
    day = Number(date[2]);
  }

  var date = new Date(year, month, day)
  return date;
}

function dateAfterNumM(d, mplus) {
  return new Date(d.getFullYear(), d.getMonth() + mplus, d.getDate())
}

function dateTostring(date) {
  if (typeof (date) == "string") return date;
  var year = date.getFullYear();
  var month = date.getMonth().toString().padStart(2, "0");
  var day = date.getDate().toString().padStart(2, "0");
  return `${year} / ${month} / ${day}`
}
////////////////////////////////////////////////////


function setresultvalue(value) {
  var span = document.getElementById("result");
  var incr = value > 200 ? Math.ceil(value / 200) : 1;
  var c = 0;
  console.log(incr)
  var timer = setInterval(() => {

    span.innerHTML = `${c++} <span style="font-size: 20px;">ضابط صف</span>`
    if (c >= value) {
      span.innerHTML = `${value} <span style="font-size: 20px;">ضابط صف</span>`
      clearInterval(timer)
    }
    c += incr
  }, 1)

}