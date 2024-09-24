using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models;
using ZPIDI_PORTAL.Models.DataBase;

namespace ZPIDI_PORTAL.Controllers
{
    public class MONITORController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();

        public ActionResult MonitorRepartidores()
        {
            return View("../Admin_Page/MonitorRepartidores/Index");
        }


        public PartialViewResult ConsultarCierresDelivery(int[] id_plataformas)
        {
            var cierres = db.C_Delivery_Pagos_Plataformas.Where(x => id_plataformas.Contains((int)x.id_plataforma) && x.activo == true).ToList();
            return PartialView("../Admin_Page/MonitorRepartidores/_HistorialCierres",cierres);
        }


        public bool ValidarCierreDobleDiario(int id_plataforma)
        {
            var valid = db.C_Delivery_Pagos_Plataformas.Where(x => x.id_plataforma == id_plataforma && x.fecha_corte >= DateTime.Today && x.activo == true).ToList();
            if (valid.Count() > 0)
            {
                return false;
            }
            return true;
        }

        public bool GenerarCierreDelivery(decimal monto, int id_plataforma, string observaciones)
        {
            try
            {
                int id_usuario_sesion = (int)Session["ses_id_usuario"];
                var cal = CultureInfo.CurrentCulture.Calendar;
                int no_semana = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                C_Delivery_Pagos_Plataformas cierre = new C_Delivery_Pagos_Plataformas();
                cierre.id_status_pago = 1;
                cierre.semana_corte = no_semana;
                cierre.monto_semana = monto;
                cierre.id_plataforma = id_plataforma;
                cierre.id_usuario_genera = id_usuario_sesion;
                cierre.fecha_corte = DateTime.Now;
                cierre.observaciones = observaciones;
                cierre.activo = true;
                db.C_Delivery_Pagos_Plataformas.Add(cierre);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public PartialViewResult VerCierreSolcitado(int id_plataforma)
        {
            var cierre = db.C_Delivery_Pagos_Plataformas.Where(x => x.id_plataforma == id_plataforma && x.activo == true && x.id_usuario_autoriza == null).ToList();
            if (cierre.Count() > 0) { return PartialView("../Admin_Page/MonitorRepartidores/_CierresGenerados", cierre); }
            else { return PartialView("../Admin_Page/MonitorRepartidores/_CierresGenerados", null); }
        }

        public bool AutorizaCierreProveedor(int id_cierre_solicitud, string NIP)
        {
            try
            {
                int id_usuario_sesion = (int)Session["ses_id_usuario"];
                var cierre = db.C_Delivery_Pagos_Plataformas.Find(id_cierre_solicitud);
                cierre.id_usuario_autoriza = id_usuario_sesion;
                cierre.NIP = NIP;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string ms = ex.ToString();
                return false;
            }
        }



        public PartialViewResult ConsultarOrdenesRepartidor(int id_repartidor)
        {
            var ordenes = from ordRepa in db.C_Delivery_Repartidores_Ordenes
                          join ord in db.C_Delivery_StartOrders on ordRepa.id_order equals ord.id_order
                          join sema in db.C_Delivery_estatus_semaforo on ordRepa.id_order equals sema.id_orden
                          where ordRepa.id_repartidor == id_repartidor && ordRepa.fecha >= DateTime.Today
                          && (sema.status_semaforo != 6 && sema.status_semaforo != 7 && sema.status_semaforo != 8)
                          select ord;
            return PartialView("../Admin_Page/MonitorRepartidores/_OrdenesRepartidor", ordenes);
        }

        public int QuitarOrdenRepartidor(int id_orden)
        {
            try
            {
                var orden = db.C_Delivery_Repartidores_Ordenes.Where(x => x.id_order == id_orden).FirstOrDefault();
                orden.id_repartidor = null;
                orden.status = true;
                db.SaveChanges();

                try
                {
                    //string codigo_suc = db.C_Delivery_StartOrders.Where(x => x.id_order == id_orden).FirstOrDefault().sucursal;
                    //C_Delivery_estatus_semaforo_log log = new C_Delivery_estatus_semaforo_log();
                    //log.id_orden = id_orden;
                    //log.fecha = DateTime.Now;
                    //log.status_nuevo = 12;
                    //log.activo = true;
                    //log.ya_llegue = false;
                    //log.codigo_sucursal = codigo_suc;
                    //db.C_Delivery_estatus_semaforo_log.Add(log);
                    //db.SaveChanges();
                    var trackZP = db.Delivery_61_Set_Trafico_Tracking("bQBh-HIAd-BlAH-ALAA", orden.id_order, "delivery_reasigna_orden");


                }
                catch (Exception ex)
                {
                    string msj = ex.ToString();
                }
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }

    }
}