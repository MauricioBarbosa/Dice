let index = {

    usuario:"",
    btnLogarOnClick: function(){

        let emailUsuario = document.getElementById("emailLog").value;
        let senhaUsuario = document.getElementById("senhaLog").value;

        let dados = {
            email: emailUsuario,
            senha: senhaUsuario
        }

        var config = {
            method: "POST",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
            body: JSON.stringify(dados) //serializa
        };

        fetch("Login/Logar", config)
            .then(function (dadosJson) {
            var obj = dadosJson.json();
            return obj;
        })
        .then(function (dadosObj) {
            console.log(dadosObj);
            document.getElementById("divMsg").innerHTML = dadosObj.msg;
        })
        .catch(function () {
            document.getElementById("divMsg").innerHTML = "deu certo";
         })    

    }
}