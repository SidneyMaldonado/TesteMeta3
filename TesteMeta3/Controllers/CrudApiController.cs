using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteMeta2.Core;

namespace TesteMeta2.Controllers
{

    [Serializable]
    public class CrudApiController : ApiController
    {
        // GET: api/CrudApi
      
        public Query Get(String id)
        {
            DadosController dc = new DadosController();
            dc.Usuario = new Usuario() { Codigo = 1, Nome = "Admin", Email = "" };
            Engine engine = new Engine(dc.Usuario);
            dc.Tabela = engine.PrepararTabela(int.Parse(id)); ;
            dc.Pagina = 1;
            dc.Id = id;
            Query query = new Query();
            query.Tabela = dc.Tabela;
            query.Registros = engine.ConsultarRegistros(dc);
            return query;
        }

        // POST: api/CrudApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CrudApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CrudApi/5
        public void Delete(int id)
        {
        }
    }
}
