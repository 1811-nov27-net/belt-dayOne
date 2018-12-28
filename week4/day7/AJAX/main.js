'use strict';

function ajaxGet(
    url, 
    success,
    failure = res => console.log(res)){
        let xhr = new XMLHttpRequest();
        xhr.addEventListener("readystatechange", () =>{
            console.log(`ready-state is now: ${xhr.readyState}`);
            if(xhr.readyState === 4){
                let responseJSON = xhr.response;
                if (xhr.status >= 200 && xhr.status < 300){
                    success(xhr.response);
                }
                else {
                    failure(xhr.response);
                }
            }
        });
        xhr.open("GET", url);
        xhr.send();
    }

document.addEventListener("DOMContentLoaded", () => {
    let jokeHeader = document.getElementById("jokeHeader");
    let jokeBtn = document.getElementById("jokeBtn");
    let jokeFetchBtn = document.getElementById("jokeFetchBtn");

    jokeBtn.addEventListener("click", () => {
        ajaxGet("https://api.icndb.com/jokes/random", response =>{
                    let responseObj = JSON.parse(response);
                    console.log(responseObj);
                    let joke = responseObj.value.joke;
                    jokeHeader.innerText = joke;
        });
    });
        console.log("request about to be sent");
        jokeFetchBtn.addEventListener("click", ()=> {
            fetch("https://api.icndb.com/jokes/random")
                .then(response => response.json())
                .then(obj => {
                    jokeHeader.innerText = obj.value.joke;
                });
        });
        
});

