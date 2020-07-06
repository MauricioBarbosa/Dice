var Index = {
    carregarCategorias() {
        var config = {
            method: "GET",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: "include"
        };

        document.getElementById("#divTable").classList.replace('d-none', 'd-flex')
        var tabela = document.getElementById("#table");
        tabela.classList.replace('d-none', 'd-table')
        var thead = document.getElementById("#thead");
        var tbody = document.getElementById("#resultadoPesquisa");
        var divTable = document.getElementById("#divTable")
        divTable.innerHTML = `<div class="d-flex">
        <div><img src=\"/Images/ajax-loader.gif" /></div>
        <div> Carregando...</div>`;
        var pesquisa = encodeURIComponent(document.getElementById("#busca").value);

        fetch("/CadastrarProduto/carregarCategorias?pesquisa=" + pesquisa, config)
            .then((dadosJson) => {
                var obj = dadosJson.json();
                return obj;
            })
            .then((dadosObj) => {
                if (dadosObj.hasOwnProperty("message")) {
                    document.getElementById("#divTable").innerHTML = `<div class="bg-danger d-flex">
                    <i class="fas fa-times"></i>"${dadosObj.message}"
                    </div>`;
                }
                else {
                    tabela.style.display = "table";
                    var linhas = "";
                    for (var i = 0; i < dadosObj.length; i++) {
                        linhas += `<tr class="row" data-id="${dadosObj[i].id}">
                    <th class="col-9">${dadosObj[i].nome}</th>
                    <th class="col-1"><button type="button" class="btn btn-outline-danger"><i class="fas fa-trash-alt"></i></button></th>
                    <th class="col-1"><button type="button" class="btn btn-outline-success"><i class="fas fa-edit"></i></button></th>
                    <th class="col-1"><button type="button" class="btn btn-outline-success" id="${dadosObj.id}" 
onclick="Index.setCategoria({id : ${dadosObj[i].id},nome: '${dadosObj[i].nome}'})"><i class="fas fa-check-circle"></i></button></th>
                </tr>`
                    }
                    tbody.innerHTML = linhas;
                    divTable.innerHTML = tabela.outerHTML;
                }
            })
            .catch((err) => {
                document.getElementById("#divTable").innerHTML = `<div class="bg-danger d-flex justify-content-center">
                    <i class="fas fa-times"></i> Erro `+ err + `
                    </div>`;
            })
    }, 
    setCategoria(categoria) {
        window.parent.categoria = categoria;
        window.parent.document.getElementById("categoriaProduto").value = categoria.nome; 
        window.parent.$.fancybox.close();
    } 
}

Index.carregarCategorias();
