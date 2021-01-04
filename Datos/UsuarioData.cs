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
    }
}
