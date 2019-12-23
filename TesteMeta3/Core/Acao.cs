using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class Acao
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public bool Habilitado { get; set; }
        public bool AcaoNoRegistro { get; set; }
        public bool AcaoMultiploRegistro { get; set; }
        public bool EstadoBotao { get; set; }
        public string UrlImagem { get; set; }
        public string Procedure { get; set; }
        public string nm_html_imprimir_registro { get; set; }
        public string pre_condicao { get; set; }
        public string pos_condicao { get; set; }

        public List<Acao> Acoes;

        public Acao(int codigo, string nome, string titulo, bool habilitado, bool acaonoregistro, string urlImagem, string nmProcedure)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Titulo = titulo;
            this.Habilitado = habilitado;
            this.AcaoNoRegistro = acaonoregistro;
            this.UrlImagem = urlImagem;
            this.Procedure = nmProcedure;
            this.AcaoMultiploRegistro = false;
        }

        public Acao(int codigo, string nome, string titulo, bool habilitado, bool acaonoregistro, bool acaomultiploregistros, string urlImagem, string nmProcedure)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Titulo = titulo;
            this.Habilitado = habilitado;
            this.AcaoNoRegistro = acaonoregistro;
            this.AcaoMultiploRegistro = acaomultiploregistros;
            this.UrlImagem = urlImagem;
            this.Procedure = nmProcedure;
        }

        public Acao() {  }
    }
}