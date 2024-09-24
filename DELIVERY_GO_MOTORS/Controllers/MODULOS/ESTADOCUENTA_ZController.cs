using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models;
using ZPIDI_PORTAL.Models.DataBase;

namespace ZPIDI_PORTAL.Controllers.MODULOS
{
    public class ESTADOCUENTA_ZController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();

        public ActionResult Estatus_cuenta()
        {
            try
            {
                ViewBag.token_repa = Session["ses_token"].ToString();
            }
            catch (Exception)
            {
                ViewBag.msj = "TOKEN NO ENCONTRADO";
                return View("../Public_page/MODULOS/_ErrorModule");
            }

            return View("../Public_page/MODULOS/Estado_Cuenta/EstatusCuenta/Index");
        }

        public ActionResult Ganancias_Adeudos()
        {
            try
            {
                ViewBag.token_repa = Session["ses_token"].ToString();
            }
            catch (Exception)
            {
                ViewBag.msj = "TOKEN NO ENCONTRADO";
                return View("../Public_page/MODULOS/_ErrorModule");
            }

            return View("../Public_page/MODULOS/Estado_Cuenta/Ganancias_Adeudos/Index");
        }

        public ActionResult Ganancias_Adeudos_Historial()
        {
            try
            {
                ViewBag.token_repa = Session["ses_token"].ToString();
            }
            catch (Exception)
            {
                ViewBag.msj = "TOKEN NO ENCONTRADO";
                return View("../Public_page/MODULOS/_ErrorModule");
            }

            return View("../Public_page/MODULOS/Estado_Cuenta/Ganancias_Adeudos_Historial/Index");
        }



    }
}