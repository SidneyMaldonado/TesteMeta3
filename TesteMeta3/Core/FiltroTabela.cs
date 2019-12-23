using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class FiltroTabela
    {

        public String Filtrar { get; set; }
        public string Conteudo { get; set; }

        public FiltroTabela( String filtrar, String conteudo)
        {
            this.Filtrar = filtrar;
            this.Conteudo = conteudo;
        }
    }
}