using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Datos
{
    public class UsuarioData
    {
        public List<Usuario> GetUsuarios()
        {
            PruebaJeimmy_QuiñonesEntities db = new PruebaJeimmy_QuiñonesEntities();
            return db.Usuarios.ToList();
        }
        public Usuario GetUsuario(int id)
        {
            PruebaJeimmy_QuiñonesEntities db = new PruebaJeimmy_QuiñonesEntities();
            return db.Usuarios.FirstOrDefault(x=>x.IdUsuario==id);
        }
        public string AddUsuario(Usuario user)
        {
            PruebaJeimmy_QuiñonesEntities db = new PruebaJeimmy_QuiñonesEntities();
            try
            {
                db.Usuarios.Add(user);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al agregar el usuario";
            }
            
        }
        public string SaveUsuario(Usuario user)
        {
            PruebaJeimmy_QuiñonesEntities db = new PruebaJeimmy_QuiñonesEntities();
            var model = db.Usuarios.FirstOrDefault(x => x.IdUsuario == user.IdUsuario);
            if(model!=null)
            {
                try
                {
                    model.Nombre = user.Nombre;
                    model.Email = user.Email;
                    model.Apellidos = user.Apellidos;
                    model.Numeroidentificacion = user.Numeroidentificacion;
                    db.SaveChanges();
                    return "OK";
                }
                catch(Exception e)
                {
                    return "Error al guardar los cambios";
                }
            }
            else
            {
                return "Usuario no encontrado";
            }
        }
        public string DeleteUsuario(int id)
        {
            PruebaJeimmy_QuiñonesEntities db = new PruebaJeimmy_QuiñonesEntities();
            var model = db.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            if (model != null)
            {
                try
                {
                    db.Usuarios.Remove(model);
                    db.SaveChanges();
                    return "OK";
                }
                catch (Exception e)
                {
                    return "Error al eliminar el usuario";
                }
            }
            else
            {
                return "Usuario no encontrado";
            }


        }
    }
}
