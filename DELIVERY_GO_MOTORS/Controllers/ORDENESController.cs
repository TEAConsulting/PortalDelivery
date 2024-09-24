using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models;
using ZPIDI_PORTAL.Models.DataBase;

namespace ZPIDI_PORTAL.Controllers
{
    public class ORDENESController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();


        private MODULOSController modulos = new MODULOSController();

        public PartialViewResult GetDetallePedido(int id_orden)
        {
            try
            {
                int id_pedido = db.C_Delivery_OrdenesPedidos.Where(x => x.id_orden == id_orden).FirstOrDefault().id_pedido;
                var pedido2 = db.C_pedidos.Where(x => x.id_pedido == id_pedido).ToList();

                return PartialView("../Public_Page/ORDENES/_OrdenDetail", pedido2);
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return PartialView("../Public_Page/ORDENES/_OrdenDetail", null);
            }
        }


        public PartialViewResult GetDetalleRepartidor(int id_orden)
        {
            try
            {
                int id_repa = (int)db.C_Delivery_Repartidores_Ordenes.Where(x => x.id_order == id_orden).FirstOrDefault().id_repartidor;
                var repa = db.C_Delivery_Repartidores.Where(x => x.id_repartidor == id_repa).ToList();
                return PartialView("../Public_Page/ORDENES/_RepartidorDetail", repa);
            }
            catch (Exception ex)
            {
                string ms = ex.ToString();
                return PartialView("../Public_Page/ORDENES/_RepartidorDetail", null);
            }
        }

        public int ValidarYaLlegue(int id_orden)
        {
            //0 = ERROR
            //1 = OK
            //2 = NO SE LE HA CAMBIADO EL STATUS A RECOLECTADO (ESPERANDO ASIGNACION DE TIENDA)
            try
            {
                var validOrden = db.C_Delivery_estatus_semaforo_log.Where(x => x.id_orden == id_orden && x.status_nuevo == 11).FirstOrDefault();
                if (validOrden != null)
                {
                    if (validOrden.ya_llegue == false || validOrden.ya_llegue == true) {
                        return 0;
                    }

                    return 1;
                }
                else {
                    try
                    {
                        var validStatus = db.C_Delivery_estatus_semaforo.Where(x => x.id_orden == id_orden).FirstOrDefault();
                        if (validStatus.status_semaforo != 2) { return 0; }
                        return 1;
                    }
                    catch (Exception)
                    {
                        return 1;
                    }
                }
            }
            catch (Exception)
            {
                return 1;
            }

        }

        public int YaLlegueOden(int id_orden)
        {
            try
            {
                DateTime hoy = ObtenerFechaActual();

                int id_repa = (int)db.C_Delivery_Repartidores_Ordenes.Where(x => x.id_order == id_orden).FirstOrDefault().id_repartidor;
                string codigo_suc = db.C_Delivery_StartOrders.Where(x => x.id_order == id_orden).FirstOrDefault().sucursal;

                //VALIDO LA DISTANCIA DE SUCURSAL-REPARTIDOR
                double lat_cli = 0;
                double lng_cli = 0;
                var coords_cli = db.C_Delivery_Repartidores_Ubicaciones.Where(x => x.id_repartidor == id_repa).FirstOrDefault();
                if (coords_cli != null)
                {
                    lat_cli = Convert.ToDouble(coords_cli.latitud);
                    lng_cli = Convert.ToDouble(coords_cli.longitud);
                }

                double lat_suc = 0;
                double lng_suc = 0;
                var coords_suc = db.C_Delivery_sucursales_gps.Where(x => x.codigo_sucursal == codigo_suc).FirstOrDefault();
                if (coords_suc != null)
                {
                    lat_suc = coords_suc.lat;
                    lng_suc = coords_suc.@long;
                }
                var distanciaSucCliente = db.usp_Distancia_dos_puntos(lat_suc, lng_suc, lat_cli, lng_cli);
                decimal distancia_repa = Convert.ToDecimal(distanciaSucCliente.FirstOrDefault()) * 1000;
                decimal distancia_tolerancia = (decimal)db.C_Delivery_Parametros.Find(1003).valor_numerico;
                if (distancia_repa > distancia_tolerancia) { return 1; }

                //OBTENGO TODAS LAS ORDENES DEL REPARTIDOR DE ESA SUCURSAL PARA INSERTAR EL YA LLEGUÉ
                var pedidosRepa = from repOrd in db.C_Delivery_Repartidores_Ordenes
                                  join estatus in db.C_Delivery_estatus_semaforo on repOrd.id_order equals estatus.id_orden
                                  join ordenes in db.C_Delivery_StartOrders on repOrd.id_order equals ordenes.id_order
                                  where (estatus.status_semaforo == 2 ) && repOrd.id_repartidor == id_repa && ordenes.sucursal == codigo_suc
                                  select repOrd;

                foreach (var item in pedidosRepa.Select(x => x.id_order).ToArray().Distinct())
                {
                    int id_orden_repa = item;
                    var validPideYa = db.C_Delivery_estatus_semaforo_log.Where(x => x.id_orden == id_orden_repa && x.status_nuevo == 11).FirstOrDefault();
                    if (validPideYa == null)
                    {
                        C_Delivery_estatus_semaforo_log log = new C_Delivery_estatus_semaforo_log();
                        log.codigo_sucursal = codigo_suc;
                        log.id_orden = id_orden_repa;
                        log.fecha = hoy;
                        log.status_nuevo = 11;
                        log.ya_llegue = true;
                        log.activo = true;
                        db.C_Delivery_estatus_semaforo_log.Add(log);

                        try
                        {
                            var trckZP2 = db.Delivery_61_Set_Trafico_Tracking("bQBh-HIAd-BlAH-ALAA", id_orden_repa, "repartidor_ya_llegue");
                        }
                        catch (Exception ex)
                        {
                            string msj = ex.ToString();
                        }
                    }
                }
                db.SaveChanges();

                //foreach (var item in pedidosRepa.Select(x => x.id_order).ToArray().Distinct())
                //{
                    
                //}

                return 0;
                
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return -1;
            }
        }


        public DateTime ObtenerFechaActual()
        {
            string fechaHoy = "";
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                string cadena = @"Data Source=200.92.216.34,4325;Initial Catalog=DB_ZPIDI_QAS;Persist Security Info=True;User ID=sa;Password=$QP.85130886$#1";
                SqlConnection mSqlCnn = new SqlConnection(cadena);
                sqlCmd.CommandText = "SELECT GETDATE()";
                sqlCmd.Connection = mSqlCnn;
                mSqlCnn.Open();
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fechaHoy = reader[0].ToString();
                    }
                }
                mSqlCnn.Close();
            }
            DateTime FECHA = DateTime.Parse(fechaHoy);
            return FECHA;
        }



        //-------------- TRACKING CC - CLIENTE
        public ActionResult TrackingOrdenZPIDI(string tkn)
        {
            try
            {
                //string token = Request.Params["tkn"];
                int id_orden = (int)db.C_Delivery_Ordenes_Tokens.Where(x => x.token_dyn == tkn).FirstOrDefault().id_orden;

                int id_status = db.C_Delivery_estatus_semaforo.Where(x => x.id_orden == id_orden).FirstOrDefault().status_semaforo;
                string status_orden = db.C_Delivery_estatus_semaforo_alias.Where(x => x.id_semaforo == id_status).FirstOrDefault().descripcion;
                int id_pedido = (int)db.C_Delivery_OrdenesPedidos.Where(x => x.id_orden == id_orden).FirstOrDefault().id_pedido;
                var suc = db.C_Delivery_StartOrders.Where(x => x.id_order == id_orden).FirstOrDefault().C_Delivery_sucursales_gps.nombre_suc;

                ViewBag.id_pedido = id_pedido;
                ViewBag.status_orden = status_orden;
                ViewBag.id_orden = id_orden;
                ViewBag.token = tkn;
                ViewBag.nombre_sucursal = suc;


                return View("../Public_Page/ORDENES/TrackingOrden/Index");
            }
            catch (Exception)
            {
                return modulos.DefaultView("Orden no encontrada");
            }

        }



        public string ConsultarModoTracking(int id_orden)
        {
            var sema = db.C_Delivery_estatus_semaforo.Where(x => x.id_orden == id_orden).FirstOrDefault();
            if (sema == null) { return "5|Orden no encontrada"; }

            int id_semaforo = sema.status_semaforo;

            //1 -> Coordenadas Sucursal
            //2 -> Coordenadas Repa - Sucursal
            //3 -> Coordenadas Repa - Cliente
            //4 -> Terminada o Cancelada
            //5 -> Orden no encontrada

            string status_orden = db.C_Delivery_estatus_semaforo_alias.Where(x => x.id_semaforo == id_semaforo).FirstOrDefault().descripcion;

            //NO SE AH ACEPTADO NI PUESTO EN CAMINO Y SE LE MUESTRAN SOLO LAS COORDENADAS DE LA SUCURSAL
            if (id_semaforo == 1 || id_semaforo == 2)
            {
                var validOrden = db.C_Delivery_Repartidores_Ordenes.Where(x => x.id_order == id_orden && x.id_repartidor != null).FirstOrDefault();
                //YA SE ACEPTÓ POR UN REPARTIDOR
                if (validOrden != null) { return "2|" + status_orden; }

                return "1|" + status_orden;
            }
            
            //YA VA EN CAMINO A LA SUCURSAL
            if (id_semaforo == 4 || id_semaforo == 3){ return "3|" + status_orden; }

            

            //TERMINADA O CANCELADA
            if (id_semaforo == 5 || id_semaforo == 6){ return "4|" + status_orden; }

            //NIGUN ESTATUS QUE JUEGUE EN EL TRACKING
            else{ return "4|" + status_orden; }

        }


        public string GetCoordenadasSucursal(int id_orden)
        {
            var CoordsSuc = from ord in db.C_Delivery_StartOrders
                            join Coordsuc in db.C_Delivery_sucursales_gps on ord.sucursal equals Coordsuc.codigo_sucursal
                            where ord.id_order == id_orden
                            select new { Coordsuc.lat, Coordsuc.@long, };
            return Newtonsoft.Json.JsonConvert.SerializeObject(CoordsSuc);
        }


        public string GetCoordenadasRepaSucursal(int id_orden)
        {
            var coordenadas = from Coordsuc in db.C_Delivery_sucursales_gps
                              join ord in db.C_Delivery_StartOrders on Coordsuc.codigo_sucursal equals ord.sucursal
                              join ordRep in db.C_Delivery_Repartidores_Ordenes on ord.id_order equals ordRep.id_order
                              join CoordRepa in db.C_Delivery_Repartidores_Ubicaciones on ordRep.id_repartidor equals CoordRepa.id_repartidor
                              where ordRep.id_order == id_orden
                              select new
                              {
                                  Coordsuc.lat,Coordsuc.@long,
                                  CoordRepa.latitud,CoordRepa.longitud
                              };
            return Newtonsoft.Json.JsonConvert.SerializeObject(coordenadas);
        }


        public string GetCoordenadasRepaSucursalCliente(int id_orden)
        {
            var orden = from repOrd in db.C_Delivery_Repartidores_Ordenes
                        join coordRepa in db.C_Delivery_Repartidores_Ubicaciones on repOrd.id_repartidor equals coordRepa.id_repartidor
                        join coordCliente in db.C_Delivery_StartOrders on repOrd.id_order equals coordCliente.id_order
                        join coordSuc in db.C_Delivery_sucursales_gps on coordCliente.sucursal equals coordSuc.codigo_sucursal
                        where repOrd.id_order == id_orden
                        select new
                        {
                            coordRepa.latitud,coordRepa.longitud,
                            coordCliente.lat,coordCliente.@long,
                            lat_suc = coordSuc.lat, long_suc = coordSuc.@long
                        };
            return Newtonsoft.Json.JsonConvert.SerializeObject(orden);
        }






        public PartialViewResult GetInfoPedido(int id_orden)
        {
            int id_pedido = db.C_Delivery_OrdenesPedidos.Where(x => x.id_orden == id_orden).FirstOrDefault().id_pedido;
            var pedido = db.C_pedidos.Where(x => x.id_pedido == id_pedido).ToList();
            return PartialView("../Public_Page/ORDENES/TrackingOrden/_InfoPedido", pedido);
        }
        public PartialViewResult GetInfoRepartidor(int id_orden)
        {
            var repartidor = from repa in db.C_Delivery_Repartidores
                             join orden in db.C_Delivery_Repartidores_Ordenes on repa.id_repartidor equals orden.id_repartidor
                             where orden.id_order == id_orden
                             select repa;
            return PartialView("../Public_Page/ORDENES/TrackingOrden/_InfoRepartidor", repartidor);
        }



    }
}