using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class Usuario
    {

        public int Codigo { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public Boolean Administrador { get; set; }
        public Usuario()
        {
        }

    }
}