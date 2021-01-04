using AutoMapper;
using Entidad;
using Jeimmy_Quinones.Models;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jeimmy_Quinones.Controllers
{
    public class AplicationController : ApiController
    {
        
        [HttpGet]
        [Route("Api/Usuarios")]
        public IHttpActionResult GetUsuaios()
        {
            List<Usuario> modellist = UsuarioNegocio.GetUsuarios();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuaioViewModel>());
            var mapper = config.CreateMapper();
            var lstVm = modellist.Select(itm => mapper.Map<UsuaioViewModel>(itm)).ToList();
            return Ok(lstVm);

        }
        [HttpGet]
        [Route("Api/Usuario")]
        public IHttpActionResult GetUsuaio(int id)
        {
            Usuario model = UsuarioNegocio.GetUsuario(id);
            var mol = new UsuaioViewModel();
            mol.IdUsuario = model.IdUsuario;
            mol.Nombre = model.Nombre;
            mol.Apellidos = model.Apellidos;
            mol.Email = model.Email;
            mol.Numeroidentificacion = model.Numeroidentificacion;
            return Ok(mol);

        }
        [HttpPost]
        [Route("Api/AddUsuario")]
        public IHttpActionResult AddUsuaio(UsuaioViewModel model)
        {
            var mol = new Usuario();
            mol.IdUsuario = model.IdUsuario;
            mol.Nombre = model.Nombre;
            mol.Apellidos = model.Apellidos;
            mol.Email = model.Email;
            mol.Numeroidentificacion = model.Numeroidentificacion;
            var resul= UsuarioNegocio.AddUsuario(mol);
            return Ok(resul);
        }
        [HttpPut]
        [Route("Api/SaveUsuario")]
        public IHttpActionResult SaveUsuaio(UsuaioViewModel model)
        {
            var mol = new Usuario();
            mol.IdUsuario = model.IdUsuario;
            mol.Nombre = model.Nombre;
            mol.Apellidos = model.Apellidos;
            mol.Email = model.Email;
            mol.Numeroidentificacion = model.Numeroidentificacion;
            var resul = UsuarioNegocio.SaveUsuario(mol);
            return Ok(resul);
        }
        [HttpDelete]
        [Route("Api/DeleteUsuario")]
        public IHttpActionResult DeleteUsuaio(int id)
        {
            Usuario model = UsuarioNegocio.GetUsuario(id);
            if (model!=null)
            {
                var resul = UsuarioNegocio.DeleteUsuario(id);
                return Ok(resul);
            }
            else
            {
                return Ok("No se ecuentra el usuario");
            }
            
            

        }
    }
}
