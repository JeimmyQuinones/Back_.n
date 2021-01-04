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
    }
}
