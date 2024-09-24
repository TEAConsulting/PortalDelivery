using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models;
using ZPIDI_PORTAL.Models.DataBase;

namespace ZPIDI_PORTAL.Controllers
{
    public class PLATAFORMASController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();
     

        public ActionResult AdministradorPlataformas()
        {
            return View("../Admin_Page/Plataformas/Administrador/Index");
        }
        
        public PartialViewResult ConsultarConfiguracionesPlataformas()
        {
            var config = db.C_Delivery_Plataformas_Configuracion.ToList();
            return PartialView("../Admin_Page/Plataformas/Administrador/_ConfiguracionesPlataformas", config);
        }

        public PartialViewResult EditarConfiguracionPlataforma(int id_config)
        {
            var config = db.C_Delivery_Plataformas_Configuracion.Where(x => x.id_pataforma_configuracion == id_config).ToList();
            return PartialView("../Admin_Page/Plataformas/Administrador/_EditarConfiguracion", config);
        }

        public bool ActualizarConfiguracionPlataforma(int id_config, decimal porc_zpidi, decimal porc_msj, decimal porc_repa)
        {
            try
            {
                var config = db.C_Delivery_Plataformas_Configuracion.Find(id_config);
                config.porcentaje_comision_plat = porc_zpidi;
                config.porcentaje_comision_mens = porc_msj.ToString();
                config.porcentaje_comision_repa = porc_repa.ToString();
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string mjs = ex.ToString();
                return false;
            }
        }

    }
}