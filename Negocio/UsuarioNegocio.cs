using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
namespace Negocio
{
    public class UsuarioNegocio
    {
        public static List<Usuario> GetUsuarios()
        {
            UsuarioData data = new UsuarioData();
            return data.GetUsuarios();
        }
        public static Usuario GetUsuario(int id)
        {
            UsuarioData data = new UsuarioData();
            return data.GetUsuario(id);
        }
        public static string AddUsuario(Usuario user)
        {
            UsuarioData data = new UsuarioData();
            return data.AddUsuario(user);

        }
        public static string SaveUsuario(Usuario user)
        {
            UsuarioData data = new UsuarioData();
            return data.SaveUsuario(user);
        }
        public static string DeleteUsuario(int id)
        {
            UsuarioData data = new UsuarioData();
            return data.DeleteUsuario(id);
        }
    }
}
