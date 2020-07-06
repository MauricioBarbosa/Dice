var index = {

    buildShoppingCart(obj, carrinho) {
        var text = "";
        var valorTotal = 0;
        for (var i = 0; i < obj.length; i++) {
            valorTotal += obj[i].preco * carrinho[i].qtde;
            text += `
            <div class="d-flex justify-content-start py-4 pl-5 border-bottom" href="#">
                <a href="Produto/?id=${obj[i].id}">
                    <img src="/CadastrarProduto/ObterFoto?id=${obj[i].id}" class="img-principal" />
                </a>
                <div class="d-flex flex-column mx-4">
                    <a href="Produto/?id=${obj[i].id}">
                        <b class="f-25">${obj[i].nome.toUpperCase()}</b>
                    </a>
                    <div>
                        <small class="f-color-wine">Estimativa de envio de 2 a 3 dias</small>
                    </div>
                    <div class="d-flex flex-column">
                        <small>Vendido por : <a href="#">${obj[i].fabricante}</a></small>
                        <small>Opções de presente disponíveis.<a href="#"> Saiba Mais</a></small>
                    </div>
                    <div class="d-flex my-3">
                        <div class="d-flex align-items-center border-right w-35 pr-3">
                            <label class="pt-1 mr-2">Qtde: </label>
                            <input type="number" class="form-control " min="1" max="9999" value="${carrinho[i].qtde}"/>
                        </div>
                        <div class="border-right pt-2 px-3">
                            <small><a href="#">Excluir</a></small>
                        </div>
                        <div class="border-right pt-2 px-3">
                            <small><a href="#">Salvar para mais tarde</a></small>
                        </div>
                    </div>
                </div>
                <div class="ml-auto mr-5">
                    <b class="f-25 f-color-greenblue">${(carrinho[i].qtde * obj[i].preco).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</b>
                </div>
            </div>
            `
        }
        document.getElementById("#produtosCarrinho").innerHTML = text;
        if (obj.length > 1)
            document.getElementById("#valorTotal").innerHTML = `<b>Subtotal(${obj.length} Itens): ${valorTotal.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</b>`;
        else 
            document.getElementById("#valorTotal").innerHTML = `<b>Subtotal(${obj.length} Item): ${valorTotal.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</b>`;
    },

    async initCarrinho() {

        var carrinho = localStorage.getItem("carrinho");
        carrinho = JSON.parse(carrinho)

        console.log(carrinho);

        var config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: "include"
        };

        var produtos = [];

        if (carrinho != null) {
            for (var i = 0; i < carrinho.length;i++) {

                await fetch("/Produto/obterProduto?id=" + carrinho[i].id, config)
                    .then((dadosJson) => {
                        var obj = dadosJson.json(); 
                        return obj;
                    })
                    .then((dadosObj) => {
                        produtos.push(dadosObj);
                    })
            }

            console.log(produtos)
            if (produtos.length > 0)
                index.buildShoppingCart(produtos, carrinho);

        } else {
            document.getElementById("#produtosCarrinho").innerHTML = "Não há produtos no carrinho!"
        }
    }
}

index.initCarrinho();