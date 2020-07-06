var index = {
    btnCadastrar: function () {
        var nomeUsuario = document.getElementById("nomeUsu").value;
        var sobrenomeUsuario = document.getElementById("sobrenomeUsu").value;
        var CPFUsuario = document.getElementById("CPFUsu").value;
        var enderecoUsuario = document.getElementById("enderecoUsu").value;
        var CEPUsuario = document.getElementById("cepUsu").value;
        var telefoneUsuario = document.getElementById("TelefoneUsu").value;
        var observacaoUsuario = document.getElementById("observacaoUsu").value;
        var emailUsuario = document.getElementById("emailUsu").value;
        var senhaUsuario = document.getElementById("senhaUsu").value;
        var senhaconfirmacaoUsuario = document.getElementById("senhaconfirmacaoUsu").value;

        if (nomeUsuario.trim() == "") {
            document.getElementById("divMsgNome").innerHTML = "nome vazio";
        } else if (sobrenomeUsuario.trim() == "") {
            document.getElementById("divMsgSobrenome").innerHTML = "nome vazio";
        } else if (CPFUsuario.trim() == "") {
            document.getElementById("divCPF").innerHTML = "CPF Vazio";
        } else if (enderecoUsuario.trim() == "") {
            document.getElementById("divEndereco").innerHTML = "Endereço Vazio";
        } else if (CEPUsuario.trim() == "") {
            document.getElementById("divCep").innerHTML = "CEP vazio";
        } else if (telefoneUsuario.trim() == "") {
            document.getElementById("divTelefone").innerHTML = "Telefone Vazio";
        } else if (emailUsuario.trim() == "") {
            document.getElementById("divEmail").innerHTML = "email vazio";
        } else if (senhaUsuario.trim() == "") {
            document.getElementById("divSenha").innerHTML = "senha Vazia";
        } else if (senhaconfirmacaoUsuario.trim() == "") {
            document.getElementById("divconfirmacaoSenha").innerHTML = "senha não confirmada";
        } else if (senhaUsuario.trim() != senhaconfirmacaoUsuario.trim()) {
            document.getElementById("divconfirmacaoSenha").innerHTML = "as senhas não batem";
        } else {
            var data = {
                nomeUsuario,
                sobrenomeUsuario,
                CPFUsuario,
                enderecoUsuario,
                CEPUsuario,
                telefoneUsuario,
                observacaoUsuario,
                emailUsuario,
                senhaUsuario,
                senhaconfirmacaoUsuario
            }

            var config = {
                method: "POST",
                headers: {
                    "Content-Type": "application/json; charset=utf-8"
                },
                credentials: 'include',
                body: JSON.stringify(data)
            };

            fetch("CadastrarUsuario/Criar", config)
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
    },

    carregarEstados: function(){
        var config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include'
        };

        fetch("Cidade/ObterEstados", config)
            .then(function (dadosJson) {
                var obj = dadosJson.json();
                return obj;
            })
            .then(function (dadosObj) {
                var estadosUF = document.getElementById("estadosUF");
                var opts = "<option value=''></option>";
                for (var i = 0; i < dadosObj.length; i++) {
                    opts += `<option value="${dadosObj[i].uf}">${dadosObj[i].estadoNome}</option>`;
                }
                estadosUF.innerHTML = opts;
            })
    }, 

    buscarCidades: function (uf) {
        var config = {
            method: "GET", 
            headers: {
                "Content-Type" : "application/json; charset=utf-8"
            },
            credentials : 'include'
        }

        fetch("Cidade/ObterCidades?uf=" + uf, config)
            .then(function (dadosJson) {
                var obj = dadosJson.json();
                return obj;
            })
            .then(function (dadosObj) {
                var selCidade = document.getElementById("selCidade"); 
                var opts = "<option value=''></option>";
                for (var i = 0; i < dadosObj.length; i++){
                    opts += `<option value="${dadosObj[i].cidadeNome}">${dadosObj[i].cidadeNome}</option>`;
                }
                selCidade.innerHTML = opts;
            })
    }
}

index.carregarEstados();