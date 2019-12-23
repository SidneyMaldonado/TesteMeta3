using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class DadosController
    {
        public String Id { get; set; }
        public Usuario Usuario { get; set; }
        public Tabela Tabela { get; set; }
        public int Pagina { get; set; }
        public String Ordenacao { get; set; }
        public FiltroTabela Filtro { get; set; }
    }
}