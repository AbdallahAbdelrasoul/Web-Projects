function toStandingPage() {
    window.location.replace("standings.jsp");
}
function toHomePage() {
    window.location.replace("homePage.jsp");
}
function toPlayersPage() {
    window.location.replace("players.jsp");

}
function toPlayeriNFO() {
    window.location.replace("palyerInfo.jsp");

}
function toScoreAGoal() {
    window.location.replace("score_a_goal.jsp");

}
function checkform() {

    var elements = document.getElementsByClassName("inputs");
    if (elements[0].value === null || elements[0].value === "" || elements[0].value === " ") {
        alert('There is a problem with the player id field!');
        return false;
    }
    if (elements[1].value === null || elements[1].value === "" || elements[1].value === " ") {
        alert('There is a problem with the team id field!');
        return false;
    }
    if (elements[2].value === null || elements[2].value === "" || elements[2].value === " ") {
        alert('There is a problem with the player name field!');
        return false;
    }
    if (elements[3].value === null || elements[3].value === "" || elements[3].value === " ") {
        alert('There is a problem with the player position field!');
        return false;
    }
    if (elements[4].value === null || elements[4].value === "" || elements[4].value === " ") {
        alert('There is a problem with the player DOF field!');
        return false;
    } else if (elements[4].value.length > 4) {
        alert('Please Enter only the Year Of Birth! Only 4 Digits ....');
        return false;
    }


    return true;
}
function checkGOALform() {

    var elements = document.getElementsByClassName("inputs");
    if (elements[0].value === null || elements[0].value === "" || elements[0].value === " ") {
        alert('There is a problem with the team id field!');
        return false;
    }
    if (elements[1].value === null || elements[1].value === "" || elements[1].value === " ") {
        alert('There is a problem with the player id field!');
        return false;
    }
    if (elements[2].value === null || elements[2].value === "" || elements[2].value === " ") {
        alert('There is a problem with the Date field!');
        return false;
    }
    if (elements[3].value === null || elements[3].value === "" || elements[3].value === " ") {
        alert('There is a problem with the Time field!');
        return false;
    }
    return true;
}


// Ajax :-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:-:
function fun(val) {
    var request = new XMLHttpRequest();
    request.open("GET", "InsertGoal?pass=" + val, true);
    request.send();
    request.onreadystatechange = function () {
        if (request.readyState === 4 && request.status === 200) {
            var  city = document.getElementById("player_id");
            city.innerHTML = request.responseText;
        }
    };
}