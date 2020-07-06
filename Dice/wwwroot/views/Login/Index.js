var index = {

    btnLogarOnClick: function () {

        let emailUsuario = document.getElementById("emailLog").value;
        let senhaUsuario = document.getElementById("senhaLog").value;
        var msgBody = document.getElementById("divMsg");
        msgBody.style.display = "block";

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
            .then((dadosJson) => {
                console.log(dadosJson);
                var obj = dadosJson.json();
                return obj;
            })
            .then((dadosObj) => {
                console.log(dadosObj)
                msgBody.innerHTML = dadosObj.msg;

                if (dadosObj.operacao)
                    window.location.href="/Home"
            })
            .catch((err) => {
                msgBody.innerHTML = dadosObj.msg;
            })
    }
}