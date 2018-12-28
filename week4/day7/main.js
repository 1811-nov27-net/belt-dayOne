'use strict'

function alertMe(){
    alert("You clicked the element");
}


// window.onload = function(){
//     let col1 = document.getElementById("col1");
//     col1.onclick = alertMe;

// };

// window.addEventListener("load", function() {
//     let col1 = document.getElementById("col1");
//     col1.onclick = alertMe;
// });

function printEventDetails(event){
    console.log(event);
    console.log(event.target);
    console.log(this);
}

document.addEventListener("DOMContentLoaded", () => {
    let col1 = document.getElementById("col1");
    col1.addEventListener("click", alertMe);

    let header = document.getElementById("header");
    header.innerText += ", changed by JS";
    header.innerHTML = `<u>${header.innerHTML}</u>`;

    let cell = document.getElementById("cell");
    cell.addEventListener("click", printEventDetails);

    let tbody = document.getElementById("body");
    tbody.addEventListener("click", printEventDetails, true);
});