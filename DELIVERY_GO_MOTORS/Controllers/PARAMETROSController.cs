using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models;
using ZPIDI_PORTAL.Models.DataBase;

namespace ZPIDI_PORTAL.Controllers
{
    public class PARAMETROSController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();

        public ActionResult TiemposDelivery()
        {
            return View("../Admin_Page/Parametros/TiemposDelivery/Index");
        }

        public PartialViewResult ParametrosTiemposDelivery()
        {
            var parametros = db.C_Delivery_Trafico_Semaforos.Where(x => x.activo == true && x.configurable == true).ToList();
            return PartialView("../Admin_Page/Parametros/TiemposDelivery/_TiemposParametros", parametros);
        }

        public bool ActualizarParametrosTiempos(int[] id_parametros, decimal[] val_min, decimal[] val_max, decimal[] tolerancia)
        {
            try
            {
                for (int i = 0; i < id_parametros.Length; i++)
                {
                    int id_parametro = id_parametros[i];
                    var param = db.C_Delivery_Trafico_Semaforos.Find(id_parametro);
                    param.valor_minimo = val_min[i];
                    param.valor_maximo = val_max[i];
                    param.tolerancia = tolerancia[i];
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return false;
            }

        }



        public PartialViewResult ConsultarParametrosZPIDI()
        {
            var param = db.C_Delivery_Parametros.Where(x => x.tipo_parametro == true).ToList();
            return PartialView("../Admin_Page/Parametros/_ParametrosZpidi", param);
        }

        public bool GuardarParametrosZPIDI(int[] id_parametros, int[] valores)
        {
            try
            {
                for (int i = 0; i < id_parametros.Length; i++)
                {
                    int id_param = id_parametros[i];

                    var param = db.C_Delivery_Parametros.Find(id_param);
                    param.valor_numerico = valores[i];
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}