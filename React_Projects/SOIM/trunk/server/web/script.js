
function deleteButn(v) {
  // document.getElementById("").children.length
  var th = v.parentElement.parentElement
  var tr = th.parentElement
  var table = tr.parentElement
  var column = -1;
  for (let index = 0; index < tr.children.length; index++) {
    if (tr.children[index].innerHTML == th.innerHTML) { column = index; break; }
  }
  for (let index = 0; index < table.children.length; index++) {
    var child = table.children[index].children[column]
    table.children[index].removeChild(child);
  }
}
function sortBtun(v) {
  console.log(v)
}
