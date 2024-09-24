using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models;
using ZPIDI_PORTAL.Models.DataBase;

namespace ZPIDI_PORTAL.Controllers
{
    public class REPARTIDORController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();

        public PartialViewResult VerInformacionRepartidor(int id_repartidor)
        {
            var repa = db.C_Delivery_Repartidores.Where(x => x.id_repartidor == id_repartidor).ToList();
            return PartialView("../Admin_Page/SOLICITUDES/_RepartidoresInfo", repa);
        }

        public ActionResult RepartidoresTiendas()
        {
            return View("../Admin_Page/Repartidores/RepartidoresTiendas/Index");
        }


        public PartialViewResult ConsultarPlataformas()
        {
            var plataformas = db.C_Delivery_Plataformas.Where(x => x.activo == true).ToList();
            return PartialView("../CATALOGOS/_PlataformasSelect", plataformas);
        }


        public PartialViewResult ConsultarRepartidoresPlataformaSelect(int[] id_plataformas)
        {
            try
            {
                var repas = from rep in db.C_Delivery_Repartidores
                            join repSol in db.C_Delivery_Repartidores_Solicitudes on rep.id_repartidor equals repSol.id_repartidor
                            join sol in db.C_Delivery_Repartidores_Solicitud on repSol.id_solicitud equals sol.id_solicitud_repartidor
                            where id_plataformas.Contains((int)sol.id_plataforma)
                            orderby rep.nombre
                            select rep;
                return PartialView("../CATALOGOS/_RepartidoresPlataformaSelect", repas);
            }
            catch (Exception)
            {
                return PartialView("../CATALOGOS/_RepartidoresPlataformaSelect", null);
            }
        }

        public PartialViewResult ConsultarRepartidoresPlataforma(int[] id_plataformas)
        {
            try
            {
                var repas = from rep in db.C_Delivery_Repartidores
                            join repSol in db.C_Delivery_Repartidores_Solicitudes on rep.id_repartidor equals repSol.id_repartidor
                            join sol in db.C_Delivery_Repartidores_Solicitud on repSol.id_solicitud equals sol.id_solicitud_repartidor
                            where id_plataformas.Contains((int)sol.id_plataforma) orderby rep.nombre
                            select rep;
                //join plat in db.C_Delivery_Plataformas on repSol.id_
                // nota 2
                return PartialView("../Admin_Page/Repartidores/RepartidoresTiendas/_RepartidoresPlataformaTable", repas);
            }
            catch (Exception)
            {
                return PartialView("../Admin_Page/Repartidores/RepartidoresTiendas/_RepartidoresPlataformaTable", null);
            }
        }

        public PartialViewResult ConsultarSucursalesRepartidor(int[] id_repartidores)
        {
            var repa = db.C_Delivery_Repartidores_Empresas_Sucursales.Where(x => id_repartidores.Contains((int)x.id_repartidor) && x.activo == true)
                .OrderBy(x => x.C_Delivery_sucursales_gps.nombre_suc).ToList();
            return PartialView("../Admin_Page/Repartidores/RepartidoresTiendas/_RepartidoresSucursalesTable", repa);
        }

        public bool AsignarSucursalRepa(int[] id_repartidores, string codigo_sucursal)
        {
            try
            {
                int id_empresa = db.C_Delivery_sucursales_gps.Where(x => x.codigo_sucursal == codigo_sucursal).FirstOrDefault().id_empresa;
                for (int i = 0; i < id_repartidores.Length; i++)
                {
                    int id_repa = id_repartidores[i];
                    var validSuc = db.C_Delivery_Repartidores_Empresas_Sucursales.Where(x => x.id_repartidor == id_repa && x.codigo_sucursal == codigo_sucursal).FirstOrDefault();
                    if (validSuc == null)  //AGREGO
                    {
                        C_Delivery_Repartidores_Empresas_Sucursales repaSuc = new C_Delivery_Repartidores_Empresas_Sucursales();
                        repaSuc.id_repartidor = id_repa;
                        repaSuc.codigo_sucursal = codigo_sucursal;
                        repaSuc.id_empresa = id_empresa;
                        repaSuc.activo = true;
                        db.C_Delivery_Repartidores_Empresas_Sucursales.Add(repaSuc);
                    }
                    else
                    {     //ACTUALIZO
                        validSuc.activo = true;
                        db.SaveChanges();
                    }
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return false;
            }
        }


        public bool RemoverSucursalRepa(int[] id_repartidores, string codigo_sucursal)
        {
            try
            {
                for (int i = 0; i < id_repartidores.Length; i++)
                {
                    int id_repa = id_repartidores[i];
                    var validSuc = db.C_Delivery_Repartidores_Empresas_Sucursales.Where(x => x.id_repartidor == id_repa && x.codigo_sucursal == codigo_sucursal).FirstOrDefault();
                    if (validSuc != null)  //AGREGO
                    {
                        validSuc.activo = false;
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return false;
            }
        }

    }
}