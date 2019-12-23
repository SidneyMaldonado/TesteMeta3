using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class Query
    {
        public Tabela Tabela { get; set; }
        public List<Registro> Registros { get; set; }
    }
}