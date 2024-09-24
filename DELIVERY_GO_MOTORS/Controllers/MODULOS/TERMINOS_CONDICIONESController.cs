using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZPIDI_PORTAL.Controllers.MODULOS
{
    public class TERMINOS_CONDICIONESController : Controller
    {
        public ActionResult Terminos_Condiciones_Uso_Socios_Repartidores()
        {
            return View("../Public_Page/MODULOS/Terminos_Condiciones/Terminos_Condiciones_Uso_Socios_Repartidores");
        }

        public ActionResult Terminos_Condiciones_Uso_Moto()
        {
            return View("../Public_Page/MODULOS/Terminos_Condiciones/Terminos_Condiciones_Uso_Moto");
        }


    }
}