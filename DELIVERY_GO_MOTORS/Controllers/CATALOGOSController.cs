using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models;
using ZPIDI_PORTAL.Models.DataBase;

namespace ZPIDI_PORTAL.Controllers
{
    public class CATALOGOSController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ConsultarEstados()
        {
            try
            {
                var estados = db.C_Delivery_Estados.ToList();
                return PartialView("_EstadosSelect", estados);
            }
            catch (Exception ex)
            {
                return PartialView("_EstadosSelect", null);
            }
        }
        public PartialViewResult GetCiudades(int id_estado)
        {
            var ciudades = db.C_Delivery_Ciudad.Where(x => x.edo_id == id_estado).ToList();
            return PartialView("_CiudadesSelect", ciudades);
        }
        public PartialViewResult GetVehiculos()
        {
            var vehiculos = db.C_Delivery_Repartidores_Vehiculos_Tipos.Where(x => x.activo == true).ToList();
            return PartialView("_VehiculosTipos", vehiculos);
        }

        public PartialViewResult ConsultarTiposCancelacion()
        {
            var status = db.C_Delivery_TipoCancelacion.Where(x => x.estatus == true).ToList();
            return PartialView("_TiposCancelacion", status);
        }

        public PartialViewResult ConsultarEmpresas()
        {
            var empresas = db.C_Delivery_empresas.Where(x => x.activa == true).ToList();
            return PartialView("_EmpresasSelect", empresas);
        }


        public PartialViewResult ConsultarSucursalesEmpresa(int[] id_empresa)
        {
            if (id_empresa != null)
            {
                if (id_empresa[0] == 0)
                {
                    id_empresa = db.C_Delivery_empresas.Where(x => x.activa == true).Select(x => x.id_empresa).ToArray();
                }
            }

            var sucursales = db.C_Delivery_sucursales_gps.Where(x => id_empresa.Contains((int)x.id_empresa)).OrderBy(x => x.nombre_suc).ToList();
            return PartialView("_SucursalesEmpresaTable", sucursales);
        }


        public PartialViewResult ConsultarSucursalesEmpresaSelect(int[] id_empresa)
        {
            if (id_empresa != null)
            {
                if (id_empresa[0] == 0)
                {
                    id_empresa = db.C_Delivery_empresas.Where(x => x.activa == true).Select(x => x.id_empresa).ToArray();
                }
            }

            var sucursales = db.C_Delivery_sucursales_gps.Where(x => id_empresa.Contains((int)x.id_empresa)).OrderBy(x => x.nombre_suc).ToList();
            return PartialView("_SucursalesEmpresaSelect", sucursales);
        }

    }
}