using Jeimmy_Quinones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Jeimmy_Quinones.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        //Autenicación
        [HttpPost]
        public IHttpActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest("El usuario no es valido");
            //demo
            bool iscredencialvalid = (user.Password == "123456");
            if (iscredencialvalid)
            {
                var token = TokenGenerator.GenerateTokenJwt(user.Username);
                return Ok(token);
            }
            else
            {
                return Ok("Usuario no valido");
            } 
        }
    }
}
