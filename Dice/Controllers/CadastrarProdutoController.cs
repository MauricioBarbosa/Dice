using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dice.Controllers
{
    [Authorize("CookieAuth")]
    public class CadastrarProdutoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Foto()
        {
            int id = Convert.ToInt32(Request.Form["id"]);

            string msg = "OK";
            bool operacao = true;

            try
            {
                if (Request.Form.Files.Count > 2)
                    throw new Exception("Há arquivos demais");
                else
                {
                    List<byte[]> mls = new List<byte[]>();
                    for(int i=0;i< Request.Form.Files.Count; i++)
                    {
                        if(System.IO.Path.GetExtension(Request.Form.Files[i].FileName)!= ".jpg")
                        {
                            throw new Exception("Formato de imagem" +
                                " inválida na" + i+1 + "a Imagem");
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream();
                            Request.Form.Files[i].CopyTo(ms);
                            mls.Add(ms.ToArray());
                        }
                    }
                    CamadaNegocio.ProdutoCamadaNegocio pcn = 
                        new CamadaNegocio.ProdutoCamadaNegocio();
                    pcn.inserirImagem(id, mls);
                }
            }catch(Exception e)
            {
                operacao = false;
                msg = e.Message;
            }

            return Json(new {
                msg,
                operacao = true
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult obterProdutos()
        {
            List<Models.Produto> prods = new List<Produto>();
            CamadaNegocio.ProdutoCamadaNegocio pcn =
                new CamadaNegocio.ProdutoCamadaNegocio();
            try
            {
                prods = pcn.obterProdutos();

                var produtosLimpos = new List<object>();

                foreach(var p in prods)
                {
                    var produtoLimpo = new
                    {
                        id = p.Id,
                        nome = p.NomeProduto,
                        classificacao = p.ClassificacaoProduto,
                        preco_atual = p.PrecoAtual,
                        preco_antigo = p.PrecoAnterior
                    };
                    produtosLimpos.Add(produtoLimpo);
                }

                return Json(produtosLimpos);
            }
            catch(Exception e)
            {
                return Json(new
                {
                    msg = "erro",
                    codigo = false
                });
            }
        }

        [AllowAnonymous]
        public IActionResult obterFoto(int id)
        {
            CamadaNegocio.ProdutoCamadaNegocio pcn =
                new CamadaNegocio.ProdutoCamadaNegocio();

            byte[] foto;
            try
            {
                foto = pcn.obterFoto(id)[0];
            }catch(Exception e)
            {
                foto = null;
            }

            if (foto == null)
                return File("~/Images/style/noimage.jpg", "image/jpg");
            return File(foto, "image/jpg");
        }

        [AllowAnonymous]
        public IActionResult obterFoto2(int id)
        {
            CamadaNegocio.ProdutoCamadaNegocio pcn =
                new CamadaNegocio.ProdutoCamadaNegocio();

            byte[] foto;
            try
            {
                foto = pcn.obterFoto(id)[1];
            }
            catch (Exception e)
            {
                foto = null;
            }

            if (foto == null)
                return File("~/Images/style/noimage.jpg", "image/jpg");
            return File(foto, "image/jpg");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Cadastrar([FromBody]Dictionary<string,string> dados)
        {
            bool operacao = true;
            Produto p = new Produto();
            string msg = "";
            try
            {
                p.NomeProduto = dados["nomeProduto"];
                p.PrecoAtual = Double.Parse(dados["precoProduto"].ToString())/100;
                p.DescricaoProduto = dados["descricaoProduto"];
                p.FabricanteProduto = new Models.Fabricante(Convert.ToInt32(dados["fabid"]));
                p.CategoriaProduto = new Models.Categoria(Convert.ToInt32(dados["catid"]));
                p.PrecoAnterior = p.PrecoAtual * 1.5;
                p.ClassificacaoProduto = 5;

                CamadaNegocio.ProdutoCamadaNegocio pcn = 
                    new CamadaNegocio.ProdutoCamadaNegocio();
                pcn.registrarProduto(p);
            }
            catch(Exception e)
            {
                p.Id = 0;
                operacao = false;
                msg = e.Message;
            }

         return Json(new
         {
             Id = p.Id,
             operacao,
             msg
         });
        }

        public IActionResult IndexObterFabricantes()
        {
            return View();
        }

        public IActionResult IndexObterCategorias()
        {
            return View();
        }

        public IActionResult carregarFabricantes(string pesquisa)
        {
            List<Models.Fabricante> fabs = new List<Fabricante>();
            bool operacao = true;
            try
            {
                CamadaNegocio.FabricanteCamadaNegocio fcn = new CamadaNegocio.FabricanteCamadaNegocio();
                fabs = fcn.obterFabricantes(pesquisa);
                var fabricantesLimpos = new List<object>();

                foreach(var f in fabs)
                {
                    var fabricanteLimpo = new
                    {
                        id = f.Id,
                        nome = f.FabricanteNome
                    };
                    fabricantesLimpos.Add(fabricanteLimpo);
                }
                return Json(fabricantesLimpos);
            }
            catch (Exception e)
            {
                operacao = false;
                return Json(new {
                    operacao,
                    e.Message
                });
            }
        }

        public IActionResult carregarCategorias(string pesquisa)
        {
            List<Models.Categoria> cabs = new List<Models.Categoria>();
            bool operacao = true;
            try
            {
                CamadaNegocio.CategoriaCamadaNegocio ccn =
                    new CamadaNegocio.CategoriaCamadaNegocio();
                cabs = ccn.obterCategorias(pesquisa);
                var categoriasLimpas = new List<object>();

                foreach (var c in cabs)
                {
                    var categoriaLimpa = new
                    {
                        id = c.Id,
                        nome = c.CategoriaNome
                    };
                    categoriasLimpas.Add(categoriaLimpa);
                }
                return Json(categoriasLimpas);
            }
            catch (Exception e)
            {
                operacao = false;
                return Json(new
                {
                    operacao,
                    e.Message
                });
            }
        }
    }
}
