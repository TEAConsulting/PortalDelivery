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
    public class MODULOSController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();


        public ActionResult Funcion()
        {
            string clave_modulo = Request.Params["cve_objeto"];
            string token = Request.Params["token"];

            var usuario = db.C_Delivery_Repartidores.Where(x => x.token == token).FirstOrDefault();
            if (usuario == null)
            {
                ViewBag.msj = "TOKEN NO ENCONTRADO";
                return View("../Public_page/MODULOS/_ErrorModule");
            }

            var module = db.C_Delivery_Menuappbar_Modules.Where(x => x.cve_object == clave_modulo).FirstOrDefault();
            if (module == null)
            {
                ViewBag.msj = "MODULO NO ENCONTRADO";
                return View("../Public_page/MODULOS/_ErrorModule");
            }

            SetSessionVariables(usuario);

            return RedirectToAction(module.obj_name, "MODULOS");
        }


        public ActionResult Perfil()
        {
            return View("../Public_page/MODULOS/Perfil/index");
        }
        public ActionResult Estado_Cuenta()
        {
            ViewBag.token = Session["ses_token"];
            return View("../Public_page/MODULOS/Estado_Cuenta/index");
        }
        public ActionResult Notificaciones()
        {
            ViewBag.token = Session["ses_token"];
            return View("../Public_page/MODULOS/Notificaciones/index");
        }
        public ActionResult Terminos_Condiciones()
        {
            return View("../Public_page/MODULOS/Terminos_Condiciones/index");
        }
        public ActionResult Chat()
        {
            return View("../Public_page/MODULOS/Chat/index");
        }
        public ActionResult Registra_Ticket()
        {
            return View("../Public_page/MODULOS/Registra_Ticket/index");
        }

        public ActionResult Cancelaciones_ordenes()
        {
            try
            {
                string token = Request.Params["token"];
                //int id_pedido = Convert.ToInt32(Request.Params["id_orden"]);
                int id_orden = Convert.ToInt32(Request.Params["id_orden"]);

                var usuario = db.C_Delivery_Repartidores.Where(x => x.token == token).FirstOrDefault();
                if (usuario == null)
                {
                    ViewBag.msj = "TOKEN NO ENCONTRADO";
                    return View("../Public_page/MODULOS/_ErrorModule");
                }

                var validOrden = db.C_Delivery_OrdenesPedidos.Where(x => x.id_orden == id_orden).FirstOrDefault();
                if (validOrden == null)
                {
                    ViewBag.msj = "ORDEN INEXISTENTE";
                    return View("../Public_page/MODULOS/_ErrorModule");
                }

                //int id_orden = (int)db.C_Delivery_OrdenesPedidos.Where(x => x.id_pedido == id_pedido).FirstOrDefault().id_orden;

                SetSessionVariables(usuario);
                ViewBag.token = token;
                //ViewBag.id_pedido = id_pedido;
                ViewBag.id_orden = id_orden;

                return View("../Public_page/MODULOS/Cancelaciones_ordenes/index");
            }
            catch (Exception)
            {
                ViewBag.msj = "ORDEN INVALIDA";
                return View("../Public_Page/MODULOS/_ErrorModule");
            }
        }

        public bool SetSessionVariables(C_Delivery_Repartidores repa_info)
        {
            try
            {
                Session["ses_token"] = repa_info.token;
                Session["ses_nombre"] = repa_info.nombre;
                Session["ses_apellido"] = repa_info.apellido;
                Session["ses_fecha_registro"] = repa_info.fecha_registro;
                Session["ses_cve_repartidor"] = repa_info.cve_repartidor;
                Session["ses_telefono"] = repa_info.telefono;
                Session["ses_email"] = repa_info.email;
                Session["ses_foto"] = "";
                Session["ses_plataforma"] = "";
                try{ Session["ses_foto"] = repa_info.C_Delivery_Repartidores_Solicitudes.FirstOrDefault().C_Delivery_Repartidores_Solicitud.foto; }
                catch (Exception) { try { Session["ses_plataforma"] = repa_info.C_Delivery_Repartidores_Solicitudes.FirstOrDefault().C_Delivery_Repartidores_Solicitud.C_Delivery_Plataformas.nombre_plataforma; }
                    catch (Exception) {} }


                return true;
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return false;
            }
        }
        

        public ActionResult OrdenDetail()
        {
            int id_orden = Convert.ToInt32(Request.Params["id_orden"]);

            var order_detail = db.C_Delivery_OrdenesPedidos.Where(x => x.id_orden == id_orden).FirstOrDefault();
            DateTime fech = (DateTime)order_detail.fecha_pedido;
            string fecha_orden = fech.ToString("dd/M/yyyy HH:MM:tt", CultureInfo.InvariantCulture);

            int id_pedido = order_detail.id_pedido;
            int orden = (int)db.C_pedidos.Find(id_pedido).orden;

            ViewBag.id_orden = id_orden;
            ViewBag.fecha_orden = fecha_orden;
            ViewBag.orden = orden;


            return View("../Public_page/ORDENES/Index");
        }



        public ActionResult DefaultView(string msj)
        {
            ViewBag.msj = msj;
            return View("../Admin_Page/DefaultView");
        }




    }
}