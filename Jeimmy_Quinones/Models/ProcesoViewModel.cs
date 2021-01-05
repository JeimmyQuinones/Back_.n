using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jeimmy_Quinones.Models
{
    public class ProcesoViewModel
    {
        public int IdProceso { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int? Procesopadre { get; set; }
    }
    public class ProcesoListViewModel : ProcesoViewModel
    {
        public string NombreUsuario { get; set; }
        public int Identificacion { get; set; }
        public string Nombreproyectopadre { get; set; }
    }
    public class ProcesoAddViewModel 
    {
        public List<UsuaioViewModel> usuarios { get; set; }

        public List<ProcesoViewModel> procesos { get; set; }
    }

}