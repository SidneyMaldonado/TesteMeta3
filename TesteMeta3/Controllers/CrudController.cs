using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteMeta2.Core;

namespace TesteMeta2.Controllers
{
    public class CrudController : Controller
    {
        // GET: Crud222
        [Route("Crud/Index/{nome}/{page}")]
        public ActionResult Index(String id, int page)
        {
            DadosController dc = new DadosController();
            Engine engine = novoEngine();
            Tabela tabela = engine.PrepararTabela(int.Parse(id));
            dc.Usuario = PrepararUsuario();
            dc.Tabela = tabela;
            dc.Pagina = page;
            dc.Id = id;
            Session["DadosController"+id] = dc;
            AtualizarDados(engine, dc);
            return View();
        }

        [HttpPost]
        [Route("Crud/Pesquisar/{nome}")]
        public ActionResult Pesquisar(String id, String conteudo, String ordenar, String ordem)
        {
            DadosController dc = (DadosController)Session["DadosController"+id];
            if (!String.IsNullOrEmpty(conteudo))
            {
                FiltroTabela ft = new FiltroTabela("todos", conteudo);
                dc.Filtro = ft;
            }

            if (!String.IsNullOrEmpty("Ordenar"))
                dc.Ordenacao = ordem;

            Session["DadosController"+id] = dc;
            AtualizarDados(novoEngine(), dc);
            return View("index");
        }

        [Route("Crud/Limpar/{nome}")]
        public ActionResult Limpar(String id)
        {
            DadosController dc = (DadosController)Session["DadosController"+id];
            dc.Filtro = null;
            AtualizarDados(novoEngine(), dc);
            Session["DadosController"+id] = dc;
            return View("Index");
        }

        [Route("Crud/Incluir/{nome}/{id}")]
        public ActionResult Incluir(String id)
        {
            DadosController dc = (DadosController)Session["DadosController" + id];
            ViewBag.Tabela = dc.Tabela;
            foreach( Coluna c in dc.Tabela.Colunas)
                c.Conteudo = string.Empty;

            return View();
        }

        public Engine novoEngine()
        {
            Usuario usuario = PrepararUsuario();
            Engine engine = new Engine(usuario);
            return engine;
        }
        public void AtualizarDados(Engine engine, DadosController dc)
        {
            ViewBag.Tabela = dc.Tabela;
            ViewBag.Dados = engine.ConsultarRegistros(dc);
            ViewBag.Ordenacao = dc.Ordenacao;
        }
        public Usuario PrepararUsuario()
        {
            ViewBag.Title = "Consultar ";
            Usuario usuario = new Usuario();
            usuario.Codigo = 0;
            usuario.Nome = "admin";
            usuario.Administrador = true;
            return usuario;
        }


    }
}