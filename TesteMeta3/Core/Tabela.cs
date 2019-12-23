using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class Tabela
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public bool Selecionar { get; set; }
        public string NomeColunaCalculada { get; set; }
        public List<Coluna> Colunas { get; set; }
        public List<Acao> Acoes { get; set; }
        public List<Relacao> Relacoes { get; set; }
        public List<Registro> Registros { get; set; }

        public Tabela(string nome, string titulo)
        {
            this.Nome = nome;
            this.Titulo = titulo;
            Colunas = new List<Coluna>();
            Acoes = new List<Acao>();
            Relacoes = new List<Relacao>();
            this.Selecionar = false;
        }
        public Tabela()
        {
            this.Nome = "";
            this.Titulo = "";
            Colunas = new List<Coluna>();
            Acoes = new List<Acao>();
            Relacoes = new List<Relacao>();
        }

    }
}