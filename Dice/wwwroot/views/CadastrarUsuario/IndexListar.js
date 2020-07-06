var indexListar = {

    excluir: function (id) {

        if (!confirm("Deseja excluir?")) {
            return;
        }

        var config = {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            credentials: 'include',
        }; 

        fetch("/CadastrarUsuario/Excluir?Id=" + id, config) //QuerryString
            .then((dadosJson) => {
                var obj = dadosJson.json();
                return obj;
            })
            .then((dadosObj) => {
                if (dadosObj.operacao) {
                    var tr = document.querySelector("tr[data-id='" + id + "']");

                    tr.parentNode.removeChild(tr);
                }
            })
            .catch((err) => {
                alert('Erro:'+ err);
            });

        //tirar a linha
    },

    btnPesquisarOnClick: function () {

        document.getElementById("tbUsuarios").style.display = "table";
        var tbodyUsuarios = document.getElementById("tbodyUsuarios");
        tbodyUsuarios.innerHTML = `<tr><td colspan="3"><img src =\"/images/ajax-loader.gif">  Carregando...</td></tr>`;
        document.getElementById("btnPesquisar").disabled = "disabled";

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
            .then((dadosJson)=>{
                var obj = dadosJson.json();
                return obj;
            })
            .then((dadosObj) => {
                tbodyUsuarios = document.getElementById("tbodyUsuarios");
                linhas = "";

                for (var i = 0; i < dadosObj.length; i++) {
                    var template =
                        `<tr data-id="${dadosObj[i].id}">
                            <td>${dadosObj[i].id}</td>
                            <td>${dadosObj[i].nome}</td>
                            <td>
                                <a href="#" onclick ="javascript:indexListar.excluir(${dadosObj[i].id})">Excluir</a>
                            </td>
                        </tr>`
                    linhas += template
                }
                if (linhas == "") {
                    linhas = `<tr><td colspan="3">Não Encontrado</td></tr>`
                }

                tbodyUsuarios.innerHTML = linhas;
            })
            .catch((err) => {
                tbodyUsuarios.innerHTML = `<tr><td colspan="3">Erro</td></tr>`
            })
            .finally(() => {
                document.getElementById("btnPesquisar").disabled = ""
            })
            
    }
}