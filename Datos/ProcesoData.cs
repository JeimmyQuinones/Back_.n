using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Datos
{
    public class ProcesoData
    {
        public List<Proceso> GetProcesos()
        {
            PruebaJeimmy_QuiñonesEntities db = new PruebaJeimmy_QuiñonesEntities();
            return db.Procesoes.ToList();
        }
        public Proceso GetProceso(int id)
        {
            PruebaJeimmy_QuiñonesEntities db = new PruebaJeimmy_QuiñonesEntities();
            return db.Procesoes.FirstOrDefault(x => x.IdProceso == id);
        }
        public string AddProceso(Proceso model)
        {
            PruebaJeimmy_QuiñonesEntities db = new PruebaJeimmy_QuiñonesEntities();
            try
            {
                db.Procesoes.Add(model);
                db.SaveChanges();
                return "OK";
            }
            catch (Exception e)
            {
                return "Error al agregar el Proceso";
            }

        }
        public string SaveProceso(Proceso proces)
        {
            PruebaJeimmy_QuiñonesEntities db = new PruebaJeimmy_QuiñonesEntities();
            var model = db.Procesoes.FirstOrDefault(x => x.IdUsuario == proces.IdUsuario);
            if (model != null)
            {
                try
                {
                    model.IdUsuario = proces.IdUsuario;
                    model.Nombre = proces.Nombre;
                    model.Procesopadre = proces.Procesopadre;
                    db.SaveChanges();
                    return "OK";
                }
                catch (Exception e)
                {
                    return "Error al guardar los cambios";
                }
            }
            else
            {
                return "Proceso no encontrado";
            }
        }
        public string DeleteProceso(int id)
        {
            PruebaJeimmy_QuiñonesEntities db = new PruebaJeimmy_QuiñonesEntities();
            var model = db.Procesoes.FirstOrDefault(x => x.IdProceso == id);
            if (model != null)
            {
                try
                {
                    db.Procesoes.Remove(model);
                    db.SaveChanges();
                    return "OK";
                }
                catch (Exception e)
                {
                    return "Error al eliminar el Proceso";
                }
            }
            else
            {
                return "Proceso no encontrado";
            }


        }
    }
}
