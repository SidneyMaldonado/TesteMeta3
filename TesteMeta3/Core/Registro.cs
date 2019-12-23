using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class Registro
    {
        public List<String> Dados { get; set; }
        public int codigo { get; set; }
        public Registro()
        {
            Dados = new List<String>();
        }

    }
}