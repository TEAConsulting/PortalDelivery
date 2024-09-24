using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models;
using ZPIDI_PORTAL.Models.DataBase;

namespace ZPIDI_PORTAL.Controllers
{
    public class DELIVERYController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();

        public ActionResult Index()
        {
            return View("../Admin_Page/Delivery/Index");
        }


        public PartialViewResult GetTrackingDelivery(string fecha_inicio, string fecha_fin, string token, string modo, int[] id_plataformas)
        {
            try
            {
                var f1 = fecha_inicio.Replace('-', '/') + " 00:00:00";
                var f2 = fecha_fin.Replace('-', '/') + " 23:59:59";

                //DateTime f1 = DateTime.Parse(fecha_inicio + " 00:00:00");
                //DateTime f2 = DateTime.Parse(fecha_fin + " 23:59:59");

                System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
                DateTime varf1 = DateTime.ParseExact(f1, "yyyy/MM/dd hh:mm:ss", provider);
                DateTime varf2 = DateTime.ParseExact(f2, "yyyy/MM/dd HH:mm:ss", provider);

                if (modo == "1")
                {
                    varf1 = DateTime.Today;
                    varf2 = DateTime.Today.AddDays(1);
                }

                string plataformas = "";
                for (int i = 0; i < id_plataformas.Length; i++)
                {
                    plataformas += id_plataformas[i].ToString() + ",";
                }

                //var res = db.Delivery_61_Get_Trafico_Tracking(token, varf1.ToString(), varf2.ToString(), modo, plataformas);
                var res = db.Delivery_61_Get_Trafico_Tracking_Dashboard(token, varf1.ToString(), varf2.ToString(), modo, plataformas);

                return PartialView("../Admin_Page/Delivery/_TrackingDelivery", res);
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return PartialView("../Admin_Page/Delivery/_TrackingDelivery", null);
            }
        }

        public PartialViewResult GetTrackingDashboard(string fecha_inicio, string fecha_fin, string token, string modo, int[] id_plataformas)
        {
            try
            {
                System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
                // PARSEAR LA FECHA DE HOY A STRING ****
                if (modo == "1")
                {
                    fecha_inicio = DateTime.Today.ToString("yyyy-MM-dd");
                    fecha_fin = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");

                    //DateTime f1 = DateTime.ParseExact(dateString1, "dd/MM/yyyy hh:mm:ss", provider);
                    //DateTime f2 = DateTime.ParseExact(dateString2, "dd/MM/yyyy HH:mm:ss", provider);

                    //DateTime dt1 = DateTime.ParseExact(f1.ToString(), "dd/MM/yyyy hh:mm:ss tt", provider);
                    //DateTime dt2 = DateTime.ParseExact(f2.ToString(), "dd/MM/yyyy hh:mm:ss tt", provider);

                    //fecha_inicio = dt1.ToString("yyyy/MM/dd", provider);
                }

                string plataformas = "";
                for (int i = 0; i < id_plataformas.Length; i++)
                {
                    plataformas += id_plataformas[i].ToString() + ",";
                }

                var dash = db.Delivery_61_Get_Trafico_Tracking_Dashboard(token, fecha_inicio + " 00:00:00", fecha_fin + " 23:59:59", "1", plataformas);

                return PartialView("../Admin_Page/Delivery/_TrackingDashboard", dash);
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return PartialView("../Admin_Page/Delivery/_TrackingDashboard", null);
            }
            
        }

    }
}