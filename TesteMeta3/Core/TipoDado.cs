using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class TipoDado
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeSql { get; set; }
        public string NomeCS { get; set; }
        public string Delimitador { get; set; }

        public TipoDado(int codigo, string nome, string nomesql, string nomecs, string delimitador)
            : this(codigo, nome, nomesql, nomecs)
        {
            this.Delimitador = delimitador;
        }

        public TipoDado(int codigo, string nome, string nomesql, string nomecs)
        {
            this.Nome = nome;
            this.NomeSql = nomesql;
            this.NomeCS = nomecs;
            if (this.Delimitador == null)
                this.Delimitador = "'";
        }

        public TipoDado()  {  }
    }
}