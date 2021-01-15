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
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace Jeimmy_Quinones.Controllers
{
    
    public class AplicationController : ApiController
    {
        /////Microsoft.AspNet.WebApi.Cors instalar
        #region Usuarios
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
        [ResponseType(typeof(UsuaioViewModel))]
        [HttpPost]
        [Route("Api/AddUsuario")]
        public IHttpActionResult AddUsuaio(UsuaioViewModel Usuario)
        {
            if(Usuario!=null)
            {
                var mol = new Usuario();
                mol.IdUsuario = -1;
                mol.Nombre = Usuario.Nombre;
                mol.Apellidos = Usuario.Apellidos;
                mol.Email = Usuario.Email;
                mol.Numeroidentificacion = Usuario.Numeroidentificacion;
                var resul = UsuarioNegocio.AddUsuario(mol);
                return Ok(resul);
            }
            else
            {
                return Ok("Error");
            }

        }
        [HttpPut]
        [Route("Api/SaveUsuario")]
        public IHttpActionResult SaveUsuaio(UsuaioViewModel Usuario)
        {
            if (Usuario!=null)
            {
                var mol = new Usuario();
                mol.IdUsuario = Usuario.IdUsuario;
                mol.Nombre = Usuario.Nombre;
                mol.Apellidos = Usuario.Apellidos;
                mol.Email = Usuario.Email;
                mol.Numeroidentificacion = Usuario.Numeroidentificacion;
                var resul = UsuarioNegocio.SaveUsuario(mol);
                return Ok(resul);
            }
            else
            {
                return Ok("Error");
            }
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

        #endregion
        #region Procesos
        [HttpGet]
        [Route("Api/Procesos")]
        public IHttpActionResult GetProcesos()
        {
            List<Proceso> modellist = ProcesoNegocio.GetProcesos();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Proceso, ProcesoListViewModel>());
            var mapper = config.CreateMapper();
            var lstVm = modellist.Select(itm => mapper.Map<ProcesoListViewModel>(itm)).ToList();
            foreach(var item in lstVm)
            {
                var user= UsuarioNegocio.GetUsuario(item.IdUsuario);
                var u = 0;
                var name = "";
                if (item.Procesopadre != null)
                {
                     u= item.Procesopadre ?? default(int); 
                    var proc = ProcesoNegocio.GetProceso(u);
                    name = proc.Nombre;
                }
                item.NombreUsuario = user.Nombre+" "+ user.Apellidos;
                item.Nombreproyectopadre = name; 
                item.Identificacion = user.Numeroidentificacion;
            }
            return Ok(lstVm);

        }
        [HttpGet]
        [Route("Api/Proceso")]
        public IHttpActionResult GetProceso(int id)
        {
            Proceso model = ProcesoNegocio.GetProceso(id);
            var item = new ProcesoViewModel();
            item.IdProceso = model.IdProceso;
            item.IdUsuario = model.IdUsuario;
            item.Nombre = model.Nombre;
            item.Procesopadre = model.Procesopadre;
            return Ok(item);

        }
        [HttpGet]
        [Route("Api/GetAddProceso")]
        public IHttpActionResult GetAddProceso()
        {
            var model = new ProcesoAddViewModel();
            List<Usuario> modellist = UsuarioNegocio.GetUsuarios();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuaioViewModel>());
            var mapper = config.CreateMapper();
            var lstVm = modellist.Select(itm => mapper.Map<UsuaioViewModel>(itm)).ToList();
            model.usuarios = lstVm;
            List<Proceso> modellistproces = ProcesoNegocio.GetProcesos();
            var configproces = new MapperConfiguration(cfg => cfg.CreateMap<Proceso, ProcesoViewModel>());
            var mapperproces = configproces.CreateMapper();
            var lstVmproces = modellistproces.Select(itm => mapperproces.Map<ProcesoViewModel>(itm)).ToList();
            model.procesos = lstVmproces;
            return Ok(model);
        }
        [ResponseType(typeof(UsuaioViewModel))]
        [HttpPost]
        [Route("Api/AddProceso")]
        public IHttpActionResult AddProceso(ProcesoViewModel model)
        {
            if ( model!=null)
            {
                var mol = new Proceso();
                mol.IdProceso = -1;
                mol.Nombre = model.Nombre;
                mol.IdUsuario = model.IdUsuario;
                if(model.Procesopadre==-1)
                {
                    mol.Procesopadre = null;
                }
                else
                {

                    mol.Procesopadre = model.Procesopadre;
                }
                var resul = ProcesoNegocio.AddProceso(mol);
                return Ok(resul);
            }
            else
            {
                return Ok("Error");
            }
        }
        [HttpPut]
        [Route("Api/SaveProceso")]
        public IHttpActionResult SaveProceso(ProcesoViewModel model)
        {
            if (model != null)
            {
                var mol = new Proceso();
                mol.IdProceso = model.IdProceso;
                mol.Nombre = model.Nombre;
                mol.IdUsuario = model.IdUsuario;
                if (model.Procesopadre == -1)
                {
                    mol.Procesopadre = null;
                }
                else
                {

                    mol.Procesopadre = model.Procesopadre;
                }
                var resul = ProcesoNegocio.SaveProceso(mol);
                return Ok(resul);
            }
            else
            {
                return Ok("Error");
            }
        }
        [HttpDelete]
        [Route("Api/DeleteProceso")]
        public IHttpActionResult DeleteProceso(int id)
        {
            Proceso model = ProcesoNegocio.GetProceso(id);
            if (model != null)
            {
                var resul = ProcesoNegocio.DeleteProceso(id);
                return Ok(resul);
            }
            else
            {
                return Ok("No se ecuentra el usuario");
            }

        }
        #endregion

    }
}
