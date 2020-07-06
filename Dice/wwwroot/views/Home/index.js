var indexListar = {

    adicionarCarrinho(id) {
        let produtos = []

        if (localStorage.getItem("produtosCarrinho") != null)
        {
            produtosCarrinho = JSON.parse(localStorage.getItem("produtosCarrinho"))
        }

        var produto = produtosCarrinho.find(item => {
            return item.id == id  //procura na memória
        }); 

        if (produto == null) {
            produto = {
                id: id, 
                qtde : 1
            }
        }
    }
}

var Uteis = {
    buildCatalog(obj, element) {
        var text = "";
        for (var i = 0; i < obj.length; i++) {
            var preco_A = obj[i].preco_antigo.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
            var preco_R = obj[i].preco_atual.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
            var parcelas = ((obj[i].preco_atual / 12)+1.99).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
            text += `<a class="card align-items-center pt-4 w-20 b-radius-20 mx-3" href="Produto/?id=${obj[i].id}">
                <div class="d-flex justify-content-center">
                    <img src="/CadastrarProduto/ObterFoto?id=${obj[i].id}" class="card-img" />
                </div>
                <div class="card-body px-3">
                    <div><b>${obj[i].nome.toUpperCase()}</b></div>
                    <div class="f-yellow" id="#ProdutoClassificacao">
                        <i class="fas fa-star"></i>
                        <i class="fas fa-star"></i>
                        <i class="fas fa-star"></i>
                        <i class="fas fa-star"></i>
                        <i class="fas fa-star"></i>
                    </div>
                    <div style="font-size: 13px;" class="mt-2">
                        ofertas a partir de:
                    </div>
                    <div style="font-size: 20px;">
                        <small style="text-decoration: line-through;">${preco_A}</small>
                            <b>${preco_R}</b>
                    </div>
                    <div style="font-size: 13px;">
                        ou 12x de ${parcelas} sem juros
                    </div>
                </div>
            </a>`;
        }

        text += `<a class="card align-items-center pt-4 w-20 b-radius-20 mx-3 d-flex justify-content-around" href="#">
                <b style="font-size: 30px;">Ver mais<b>
            </a>`
        element.innerHTML = text;
    }
}


const Index = {

    carregarProdutos() {

        var config = {
            method: "GET",
            credentials: 'include', //inclui cookies
        };

        fetch("CadastrarProduto/obterProdutos", config)
            .then((dadosProd) => {
                var obj = dadosProd.json()
                return obj;
            })
            .then((dadosObj) => {
                if (dadosObj.hasOwnProperty('codigo')) {
                    console.log(dadosObj.msg);
                } else {
                    Uteis.buildCatalog(dadosObj, document.getElementById('#produtosDestaque'));
                    new Glider(document.querySelector('.glider-produto'), {
                        slidesToScroll: 1,
                        slidesToShow: 5,
                        draggable: false,
                        arrows: {
                            prev: '.glider-prev-produto',
                            next: '.glider-next-produto'
                        }
                    });
                }
            })
            .catch((err) => {
                console.log(err)
                document.getElementById('#produtosDestaque').innerHTML = "DEU ERRO"
            })
    },

    pesquisarProdutos() {

        var pesquisa = document.getElementById("pesquisa").value;
        var config = {
            method: "GET",
            headers: {
                "Content-Type" : "application/json; charset=utf-8"
            }, 
            credentials: "include"
        }

        fetch("Home/obterProdutosPesquisados?pesquisa="+pesquisa, config)
            .then((dadosJson) => {
                var obj = dadosJson.json();
                return obj;
            })
            .then((dadosObj) => {
                console.log(dadosObj)
                document.getElementById("produtos").innerHTML = Uteis.buildProductCatalog(dadosObj);
            })
    }

}


window.addEventListener('load', function () {

    new Glider(document.querySelector('.glider'), {
        slidesToScroll: 1,
        slidesToShow: 6,
        draggable: false,
        dots: '.dots',
        arrows: {
            prev: '.glider-prev',
            next: '.glider-next'
        }
    });

})

Index.carregarProdutos();
