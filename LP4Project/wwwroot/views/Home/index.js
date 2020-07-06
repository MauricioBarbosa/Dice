const Index = {

    carregarProdutos: function () {

        var config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json; charset=utf8"
            },
            credentials: "include"
        };

        fetch("Home/ObterProdutos?=", config)
            .then((dadosProd) => {
                var obj = dadosProd.json()
                return obj;
            })
            .then((dadosObj) => {
                var text = "";
                dadosObj.forEach(percorrer)
                function percorrer(item, index, arr) {
                    text += `
                    <div class="row px-2 card" style = "width: 18rem;" >
                        <h5 class="card-title">${arr[index].nome}</h5>
                        <img class="card-img-top" src="~/Images/sonic_the_hedgehog_good_smile_1.jpg" alt="Card image cap">
                            <div class="card-body">
                                <p class="card-text">${arr[index].descricao}</p>
                                <h6>$ ${arr[index].preco}</h6>
                                <a href="#" class="btn btn-primary">Comprar</a>
                            </div>
                    </div>
                    `
                }
                document.getElementById("produtos").innerHTML = text;
            })
    }

}

Index.carregarProdutos();