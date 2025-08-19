document.getElementById("registerForm")?.addEventListener("submit", function(e) {
    e.preventDefault();
    const name = document.getElementById("name").value;
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    if (name === "" || email === "" || password === "") {
        alert("preencha todos os campos")
    } else {
        alert("Cadastro realizado com sucesso")
    }
})