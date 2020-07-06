const tamMaxArquivo = 40000000;

var cadastrar = {
    validarImg(arrayImg) {
        var erroImg = document.getElementById("erroImg");
        var valido = true;
        console.log(arrayImg)

        if (arrayImg.length > 0 && arrayImg.length < 3) {
            for (var i = 0; i < arrayImg.length; i++) {
                if (arrayImg[i].size > tamMaxArquivo) {
                    valido = false;
                    erroImg.classList.replace('d-none', 'd-block');
                    erroImg.innerHTML = "imagem muito grande!"
                    break;
                }
            }
        } else {
            valido = false;
            erroImg.classList.replace('d-none', 'd-block');
            if (arrayImg.length == 0)
                erroImg.innerHTML = "Não há imagens do produto!";
            else
                erroImg.innerHTML = "Há imagens demais! no máximo 2 imagens";
        }
        return valido;
    },

    validar(obj) {
        var valido = true; 
        var erroNome = document.getElementById("erroNome"); 
        var erroFabricante = document.getElementById("erroFabricante");
        var erroCategoria = document.getElementById("erroCategoria");
        var erroPreco = document.getElementById("erroPreco");

        if (obj.nome == "") {
            valido = false;
            erroNome.classList.replace('d-none', 'd-block');
            erroNome.innerHTML = "O nome não pode estar vazio!"
        }

        if (obj.preco < 2.00) {
            valido = false;
            erroPreco.classList.replace('d-none', 'd-block');
            erroPreco.innerHTML = "O preço não pode ser menor que 2.00!"
        }

        if (fabricante == null || fabricante == undefined) {
            valido = false;
            erroFabricante.classList.replace('d-none', 'd-block')
            erroFabricante.innerHTML = "Não há fabricante selecionado"
        }

        if (categoria == null || categoria == undefined) {
            valido = false;
            erroCategoria.classList.replace('d-none', 'd-block');
            erroCategoria.innerHTML = "Não há categoria selecionada";
        }
        return valido;
    },

    btnCadastrarOnClick: function () {
        let nomeProduto = document.getElementById("nomeProduto").value;
        let precoProduto = document.getElementById("precoProduto").value;
        let descricaoProduto = document.getElementById("descricaoProduto").value;
        let img = document.getElementById("imgProduto");


        if (this.validar({
            nome: nomeProduto,
            preco: precoProduto
        })) {
            console.log(this.validarImg)
            if (this.validarImg(img.files)) {

                var catid = categoria.id.toString();
                var fabid = fabricante.id.toString();
                // Enviando dados do produto
                var dados = {
                    nomeProduto,
                    precoProduto,
                    descricaoProduto,
                    catid,
                    fabid
                };

                var teste = JSON.stringify(dados);
                console.log(teste)

                var config = {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json; charset=utf-8"
                    },
                    credentials : 'include',
                    body: JSON.stringify(dados)
                };

                fetch("CadastrarProduto/Cadastrar", config)
                    .then((dadosJson) => {
                        var dadosObj = dadosJson.json();
                        return dadosObj; 
                    })
                    .then((dadosObj) => {
                        if (!dadosObj.operacao) {
                            var erroGeral = document.getElementById("erroGeral");
                            erroGeral.classList.replace('d-none', 'd-block')
                            erroGeral.innerHTML = dadosObj.msg; 
                        } else {
                            var id = dadosObj.id; 

                            var fd = new FormData();
                            fd.append("foto", img.files[0]);
                            fd.append("foto2", img.files[1]);
                            fd.append("id", id);

                            var configFD = {
                                method: "POST", 
                                headers: {
                                    "Accept" : "application/json"
                                },
                                body: fd
                            }

                            fetch("CadastrarProduto/Foto", configFD)
                                .then((dadosJson) => {
                                    var obj = dadosJson.json(); 
                                    return obj;
                                })
                                .then((dadosObj) => {
                                    window.location.href = "/Home";
                                })
                                .catch((err) => {
                                    var erroGeral = document.getElementById("erroGeral");
                                    erroGeral.classList.replace('d-none','d-block')
                                    erroGeral.innerHTML = err; 
                                })
                        }
                    })

                //enviando imagens
            }
        }
    }
}

window.parent.categoria = null;
window.parent.fabricante = null;
