using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidad;
using Negocio;

namespace Jeimmy_Quinones.Controllers
{
    public class ValuesController : ApiController
    {
       
        [HttpGet]
        [Route("Usuarios")]
        public IHttpActionResult GetUsuaios()
        {
            List<Usuario> modellist = UsuarioNegocio.GetUsuarios();
            return Ok(modellist);

        }
        
    }
}
