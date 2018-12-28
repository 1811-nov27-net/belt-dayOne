'use strict'

document.addEventListener("DOMContentLoaded", () => {
    let text = document.getElementById("text");
    let btn = document.getElementById("btn");

    btn.addEventListener("click", () => {
        let textJson = JSON.stringify(text.textContent);
        console.log(textJson);
    });
});