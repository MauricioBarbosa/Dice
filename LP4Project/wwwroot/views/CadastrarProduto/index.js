let cadastrar = {

    btnCadastrarOnClick: function () {
        let nomeProduto = document.getElementById("nomeProduto").value;
        let fabricanteProduto = document.getElementById("fabricanteProduto").value;
        let categoriaProduto = document.getElementById("categoriaProduto").value;
        let precoProduto = document.getElementById("precoProduto").value;
        let descricaoProduto = document.getElementById("descricaoProduto").value;

        if (nomeProduto.trim() == "") {
            document.getElementById("divProduto").innerHTML = "Produto sem nome";
        } else if (fabricanteProduto.trim() == "") {
            document.getElementById("divFabricante").innerHTML = "Produto sem fabricante";
        } else if (precoProduto.trim() == "") {
            document.getElementById("divPreco").innerHTML = "Produto sem preço";
        } else {

            let data = {
                nome: nomeProduto,
                fabricante: fabricanteProduto,
                categoria: categoriaProduto,
                preco: precoProduto,
                descricao: descricaoProduto
            }

            var config = {
                method: "POST",
                headers: {
                    "Content-Type": "application/json; charset=utf-8"
                },
                credentials: 'include',
                body: JSON.stringify(data)
            };

            fetch("CadastrarProduto/Cadastrar", config)
                .then(function (dadosJson) {
                    var obj = dadosJson.json();
                    return obj;
                })
                .then(function (dadosObj) {
                    console.log(dadosObj);
                    document.getElementById("divMsg").innerHTML = dadosObj.msg;
                })
                .catch(function () {
                    document.getElementById("divMsg").innerHTML = "deu erro";
                })
        }
    },

    carregarCategorias: function () {
        var config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include'
        };

        fetch("Categoria/ObterCategorias", config)
            .then(function (dadosJson) {
                var obj = dadosJson.json();
                return obj;
            })
            .then(function (dadosObj) {
                var categoriaProduto = document.getElementById("categoriaProduto");
                var opts = ``;
                for (var i = 0; i < dadosObj.length; i++) {
                    opts += `<option value="${dadosObj[i]}">${dadosObj[i]}</option>`;
                }
                categoriaProduto.innerHTML = opts;
            }).catch(function () {
                document.getElementById("divMsg").innerHTML = "deu erro";
            })
    }
}

cadastrar.carregarCategorias();