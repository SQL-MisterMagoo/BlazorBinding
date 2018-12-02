// get element inner text
function getInnerText(id) {
    console.log("trying to locate " + id);
    var e = document.getElementById(id);
    return e.innerText;
}

// set element HTML
function setHtml(id, text) {
    console.log("setting the inner text on " + id);
    var e = document.getElementById(id);
    e.innerHTML = text;
}