﻿document.getElementById("loginForm")?.addEventListener("submit", function(e) {
    e.preventDefault();
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    if(email === "" || password === "") {
        alert("preencha todos os campos");
    } else{
        alert("Login realizado com sucesso")
    }
});
