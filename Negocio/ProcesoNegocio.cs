using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Negocio
{
    public class ProcesoNegocio
    {
        public static List<Proceso> GetProcesos()
        {
            ProcesoData data = new ProcesoData();
            return data.GetProcesos();
        }
        public static Proceso GetProceso(int id)
        {
            ProcesoData data = new ProcesoData();
            return data.GetProceso(id);
        }
        public static string AddProceso(Proceso model)
        {
            ProcesoData data = new ProcesoData();
            return data.AddProceso(model);

        }
        public static string SaveProceso(Proceso model)
        {
            ProcesoData data = new ProcesoData();
            return data.SaveProceso(model);
        }
        public static string DeleteProceso(int id)
        {
            ProcesoData data = new ProcesoData();
            return data.DeleteProceso(id);
        }
    }
}
