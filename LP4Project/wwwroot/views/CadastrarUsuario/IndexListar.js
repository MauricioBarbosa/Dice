var indexListar = {

    btnPesquisarOnClick: function () {

        var config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
        }; 
        //encodeURIComponent("André Menegassi") Este método trata caracteres especiais da url
        //existe também o comando decode;
        var nome = encodeURIComponent(document.getElementById("usuario").value);
        fetch("/CadastrarUsuario/Pesquisar?nome=" + nome, config) //QuerryString
            .then(function (dadosJson) {
                var obj = dadosJson.json();
                return obj;
            })
            .then(function (dadosObj) {
                console.log(dadosObj);
                document.getElementById("divMsg").innerHTML = dadosObj.msg;
            })
            .catch(function () {
                document.getElementById("divMsg").innerHTML = "erro";
            })
            
    }
}