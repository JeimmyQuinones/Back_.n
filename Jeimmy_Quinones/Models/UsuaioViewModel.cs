using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jeimmy_Quinones.Models
{
    public class UsuaioViewModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Numeroidentificacion { get; set; }
        public string Email { get; set; }
    }
}