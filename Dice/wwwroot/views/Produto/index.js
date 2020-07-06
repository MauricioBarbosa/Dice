var Index = {

    adicionarCarrinho(id) {

        let carrinho = []; 

        if (localStorage.getItem("carrinho") != null) {
            carrinho = JSON.parse(localStorage.getItem("carrinho"));
        }

        var produto = carrinho.find(item => {
            return item.id == id;
        })

        if (produto == null) {
            produto = {
                id: id,
                qtde: 1
            }

            carrinho.push(produto);
        }
        else {
            produto.qtde += 1;
        }

        document.getElementById('#badgeCarrinho').innerHTML = carrinho.length; 

        localStorage.setItem("carrinho", JSON.stringify(carrinho));
    },

    carregarProdutoPrincipal() {
        var id = new URLSearchParams(window.location.search).get('id');

        var config = {
            method: "GET",
            headers: {
                "Content-Type" : "application/json; charset=utf-8"
            },
            credentials : 'include'
        }

        var divImgsMiniaturas = document.getElementById("#imgsMiniaturas");
        var divImgs = document.getElementById("#imgsProdutos");
        var divSecaoProduto = document.getElementById("#informacoesProduto")

        fetch("/Produto/obterProduto?id=" + id, config)
            .then((dadosJson) => {
                obj = dadosJson.json();
                return obj;
            })
            .then((dadosObj) => {
                if (dadosObj.hasOwnProperty('msg')) {
                    alert(msg);
                    window.location.href = "/Home"
                }
                else {
                    var text = `
                    <button class="pb-2 carrousel-item">
                    <img src="/CadastrarProduto/obterFoto?id=${dadosObj.id}"
                         class="img-miniatura"  
                         data-carousel-index="0"
                         />
                </button>
                <button class="carrousel-item">
                    <img src="/CadastrarProduto/obterFoto2?id=${dadosObj.id}"
                         class="img-miniatura" 
                         data-carousel-index="1" 
                         />
                </button>
                    `;
                    divImgsMiniaturas.innerHTML = text;

                    text = `
                    <div>
                        <img src="/CadastrarProduto/obterFoto?id=${dadosObj.id}" class="img-principal" />
                    </div>
                    <div>
                        <img src="/CadastrarProduto/obterFoto2?id=${dadosObj.id}" class="img-principal" />
                    </div>
                    `

                    divImgs.innerHTML = text; 

                    text = `
                    <h4>${dadosObj.nome}</h4>
            <div class="pb-3">By <a href="#">${dadosObj.fabricante}</a></div>
            <div class="d-flex">
                <div class="d-flex mb-5 f-yellow pr-3">
                    <i class="fa fa-star" aria-hidden="true"></i>
                    <i class="fa fa-star" aria-hidden="true"></i>
                    <i class="fa fa-star" aria-hidden="true"></i>
                    <i class="fa fa-star" aria-hidden="true"></i>
                    <i class="fa fa-star" aria-hidden="true"></i>
                </div>
                <div class="d-flex">
                    <div> X Classificacoes</div>
                    <div> X Respostas</div>
                </div>
            </div>
            <div class="mb-2">
                ${dadosObj.informacoes}
            </div>
            <div class="mb-2">
                Por : <b style="font-size: 25px; color:#497878">${dadosObj.preco.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</b>
                <p><b>Ou até 12x de ${(dadosObj.preco / 12).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })} sem juros <a href="#">calculadora de prestações</a><b></p>
            </div>
            <div class="d-flex justify-content-start">
                <button class="btn btn-success mr-3" onclick="Index.adicionarCarrinho(${dadosObj.id})"><i class="fas fa-shopping-cart pr-2"></i>Adicionar ao Carrinho</button>
                <button class="btn btn-danger"  onclick="Index.adicionarFavorito(${dadosObj.id})"><i class="fas fa-heart pr-2" onclick="Index.adicionarFavorito(${dadosObj.id})"></i>Adicionar aos Favoritos</button>
            </div>
                    `
                    divSecaoProduto.innerHTML = text;

                    const $imgsCarrousel = document.querySelector(".glider");

                    const imgsGlider = new Glider($imgsCarrousel, {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    })

                    const $miniaturas = document.querySelectorAll("[data-carousel-index]");

                    $miniaturas.forEach($t => {
                        $t.addEventListener("click", e => {
                            const index = e.target.getAttribute("data-carousel-index");
                            console.log(e);
                            imgsGlider.scrollItem(index, true);
                        })
                    })

                }
            })
    }
}

Index.carregarProdutoPrincipal();
