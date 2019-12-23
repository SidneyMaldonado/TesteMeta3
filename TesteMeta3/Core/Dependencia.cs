using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class Dependencia
    {
        public string Nome { get; set; }
        public string Valor { get; set; }

        public Dependencia(string nome, string valor)
        {
            this.Nome = nome;
            this.Valor = valor;
        }
        public Dependencia() { }
    }
}