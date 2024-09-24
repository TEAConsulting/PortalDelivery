using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models.DataBase;

namespace ZPIDI_PORTAL.Controllers
{
    public class NEGOCIOController : Controller
    {
        private db_a872a9_gomotorsEntities dbz = new db_a872a9_gomotorsEntities();

        private ORDENESController ORDENES = new ORDENESController();

        public ActionResult Index()
        {
            return View("../Admin_Page/Negocio/Pos/Index");
        }

        public bool RegistraOrdenNegocio(C_Delivery_StartOrders start_order, int id_producto, int id_telefono_cliente_direccion, string nombre_cliente, string telefono, C_Delivery_Negocios_Direcciones C_direcciones, int id_telefono, decimal monto, decimal costo_envio)
        {
            try
            {
                if (id_telefono_cliente_direccion == 0) //REGISTRO NUEVO SIN: TELEFONO,DIRECCION Y CLIENTE
                {
                    var valid_telefono = dbz.C_Delivery_Negocios_Telefonos.Find(id_telefono);
                    if (valid_telefono == null)
                    {
                        C_Delivery_Negocios_Telefonos new_tel = new C_Delivery_Negocios_Telefonos();
                        new_tel.telefono = telefono;
                        new_tel.activo = true;
                        dbz.C_Delivery_Negocios_Telefonos.Add(new_tel);
                        dbz.SaveChanges();
                        id_telefono = new_tel.id_telefono;
                    }
                    C_Delivery_Negocios_Clientes new_cliente = new C_Delivery_Negocios_Clientes();
                    new_cliente.nombre = nombre_cliente;
                    new_cliente.telefono = telefono;
                    dbz.C_Delivery_Negocios_Clientes.Add(new_cliente);
                    dbz.C_Delivery_Negocios_Direcciones.Add(C_direcciones);
                    dbz.SaveChanges();

                    C_Delivery_Negocios_Telefonos_Clientes_Direcciones tel_cli_dir = new C_Delivery_Negocios_Telefonos_Clientes_Direcciones();
                    tel_cli_dir.id_telefono = id_telefono;
                    tel_cli_dir.id_cliente = new_cliente.id_cliente;
                    tel_cli_dir.id_direccion = C_direcciones.id_direccion;
                    dbz.C_Delivery_Negocios_Telefonos_Clientes_Direcciones.Add(tel_cli_dir);
                    dbz.SaveChanges();
                    id_telefono_cliente_direccion = tel_cli_dir.id_telefono_cliente_direccion;
                }

                if (id_telefono_cliente_direccion == -1 && id_telefono > 0) //TELEFONO EXISITENTE SIN: DIRECCION Y CIENTE
                {
                    C_Delivery_Negocios_Clientes new_cliente = new C_Delivery_Negocios_Clientes();
                    new_cliente.nombre = nombre_cliente;
                    new_cliente.telefono = telefono;
                    dbz.C_Delivery_Negocios_Clientes.Add(new_cliente);
                    dbz.C_Delivery_Negocios_Direcciones.Add(C_direcciones);
                    dbz.SaveChanges();

                    C_Delivery_Negocios_Telefonos_Clientes_Direcciones tel_cli_dir = new C_Delivery_Negocios_Telefonos_Clientes_Direcciones();
                    tel_cli_dir.id_telefono = id_telefono;
                    tel_cli_dir.id_cliente = new_cliente.id_cliente;
                    tel_cli_dir.id_direccion = C_direcciones.id_direccion;
                    dbz.C_Delivery_Negocios_Telefonos_Clientes_Direcciones.Add(tel_cli_dir);
                    dbz.SaveChanges();
                    id_telefono_cliente_direccion = tel_cli_dir.id_telefono_cliente_direccion;
                }


                //DateTime hoy = ORDENES.ObtenerFechaActual();

                DateTime hoy = DateTime.Now;
                start_order.fecha = hoy;
                dbz.C_Delivery_StartOrders.Add(start_order);
                dbz.SaveChanges();

                int id_orden = start_order.id_order;

                C_Delivery_Ordenes_Negocios orden = new C_Delivery_Ordenes_Negocios();
                orden.id_orden = id_orden;
                orden.codigo_sucursal = start_order.sucursal;
                orden.id_telefono_cliente_direccion = id_telefono_cliente_direccion;
                orden.monto = monto;
                orden.costo_envio = costo_envio;
                orden.id_tracking_status = 1;
                orden.activo = true;
                dbz.C_Delivery_Ordenes_Negocios.Add(orden);

                C_Delivery_estatus_semaforo sema = new C_Delivery_estatus_semaforo();
                sema.id_orden = id_orden;
                sema.status_semaforo = 1;
                sema.descripcion_semaforo = "Asignado";
                dbz.C_Delivery_estatus_semaforo.Add(sema);

                C_Delivery_Repartidores_Ordenes ord_repa = new C_Delivery_Repartidores_Ordenes();
                ord_repa.id_order = id_orden;
                ord_repa.status = true;
                ord_repa.fecha = hoy;
                dbz.C_Delivery_Repartidores_Ordenes.Add(ord_repa);

                C_Delivery_OrderDetail detalle = new C_Delivery_OrderDetail();
                detalle.id_order = id_orden;
                detalle.id_producto = id_producto.ToString();
                detalle.cantidad = 1;
                detalle.status = true;
                dbz.C_Delivery_OrderDetail.Add(detalle);

                dbz.SaveChanges();

                dbz.Delivery_61_Set_Trafico_Tracking(start_order.token, id_orden, "pos_inicio");


                return true;
            }
            catch (DbEntityValidationException e)
            {
                string xx = e.ToString();
                return false;

            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                //string xxx = ex.GetType();
                return false;
            }
           
        }


        public PartialViewResult BuscarCliente(string telefono)
        {
            var direcciones = dbz.C_Delivery_Negocios_Telefonos_Clientes_Direcciones.Where(x => x.C_Delivery_Negocios_Telefonos.telefono == telefono).ToList();
            return PartialView("../Admin_Page/Negocio/Pos/_ClientesDireccionesTelefono", direcciones);
        }


        public PartialViewResult ConsultarOrdenesCursoNegocio()
        {
            string codigo_sucursal = (string)Session["ses_codigo_sucursal"];
            DateTime hoy = DateTime.Today;
            var ordenes = dbz.C_Delivery_Ordenes_Negocios.Where(x => x.codigo_sucursal == codigo_sucursal && /*x.C_Delivery_StartOrders.fecha > hoy &&*/ x.activo == true && x.id_tracking_status != 5).ToList();
            return PartialView("../Admin_Page/Negocio/Pos/_TrackingOrdenesNegocio", ordenes);
        }

        public PartialViewResult ConsultarOrdenNegocio(int id_orden_negocio)
        {
            var orden = dbz.C_Delivery_Ordenes_Negocios.Where(x => x.id_orden_negocio == id_orden_negocio).ToList();
            return PartialView("../Admin_Page/Negocio/Pos/_DetalleOrdenNegocio", orden);

        }

        public PartialViewResult ConsultarOrdenesMultiples(int[] ordenes_asigna)
        {
            List<C_Delivery_Ordenes_Negocios> c_ordenes = new List<C_Delivery_Ordenes_Negocios>();
            for (int i = 0; i < ordenes_asigna.Length; i++)
            {
                int id_orden = ordenes_asigna[i];
                //var id_orden_negocio = ordenes_asigna[i];

                var orden = dbz.C_Delivery_Ordenes_Negocios.Where(x => x.id_orden == id_orden).FirstOrDefault();
                c_ordenes.Add(orden);
            }
            return PartialView("../Admin_Page/Negocio/Pos/_DetalleOrdenesMultiples", c_ordenes);
        }


        public int ValidarPedidosMultiplesZpidi(int[] ordenes_asigna)
        {
            if (ordenes_asigna != null)
            {
                List<C_Delivery_Ordenes_Negocios> c_ordenes = new List<C_Delivery_Ordenes_Negocios>();
                List<int> id_repas = new List<int>();
                for (int i = 0; i < ordenes_asigna.Length; i++)
                {
                    var id_orden_negocio = ordenes_asigna[i];

                    //VALIDO QUE TODOS LOS PEDIDOS LOS HAYA TOMADO UN REPARTIDOR
                    var validRepa = dbz.C_Delivery_Repartidores_Ordenes.Where(x => x.id_order == id_orden_negocio && x.id_repartidor != null).FirstOrDefault();
                    if (validRepa == null) { return -1; }  //SIN REPARTIDOR
                    else { id_repas.Add((int)validRepa.id_repartidor); }

                    //VALIDO QUE TODOS LOS PEDIDOS HAYAN LLEGADO  (SOLO PARA ASIGNACION)
                    var validYaLlegue = dbz.C_Delivery_estatus_semaforo_log.Where(x => x.id_orden == id_orden_negocio && x.status_nuevo == 11 && x.activo == true).FirstOrDefault();
                    if (validYaLlegue == null) { return -6; }


                    var pedido = dbz.C_Delivery_Ordenes_Negocios.Where(x => x.id_orden_negocio == id_orden_negocio).FirstOrDefault();
                    c_ordenes.Add(pedido);
                }

                //VALIDO QUE SEA EL MISMO REPARTIDOR
                if (id_repas.Distinct().Count() != 1)
                {
                    return -2;  //REPARTIDORES DIFERENTES
                }


                return 0;
            }
            else
            {
                return -4;  //NO SE SELECCIONARON PEDIDOS
            }
        }

        public PartialViewResult BuscarRepartidorZpidi(string cve)
        {
            var repa = dbz.C_Delivery_Repartidores.Where(x => x.cve_repartidor == cve).ToList();
            if (repa != null)
            {
                return PartialView("../Admin_Page/Negocio/Pos/_DatosRepartidorZpidi", repa);
            }
            return PartialView("../Admin_Page/Negocio/Pos/_DatosRepartidorZpidi", null);
        }


        public bool CambiarStatusOrdenNegocio(int id_orden_negocio, int id_orden, int id_tracking_status)
        {
            try
            {
                var orden_negocio = dbz.C_Delivery_Ordenes_Negocios.Find(id_orden_negocio);
                orden_negocio.id_tracking_status = id_tracking_status;
                dbz.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public int AsignarRepartidorZpidiMultiple(int id_repartidor, int[] id_ordenes, int id_tipo_pago, int id_status)
        {
            for (int i = 0; i < id_ordenes.Length; i++)
            {
                int id_orden = id_ordenes[i];
                var validRepaZpidi = dbz.C_Delivery_Repartidores_Ordenes.Where(x => x.id_order == id_orden).FirstOrDefault();
                if (validRepaZpidi == null)
                {
                    return 0;  //NO HA SIDO ACEPTADO POR UN REPARTIDOR
                }
                if (validRepaZpidi != null)
                {
                    if (validRepaZpidi.id_repartidor == null)
                    {
                        return -2;
                    }
                    if (validRepaZpidi.id_repartidor != id_repartidor)
                    {
                        return -1; //EL REPARTIDOR A ASIGNAR ES DIFERENTE AL DE LA APP
                    }
                }
            }


            for (int i = 0; i < id_ordenes.Length; i++)
            {
                try
                {
                    int id_orden = id_ordenes[i];
                    var validRepaZpidi = dbz.C_Delivery_Repartidores_Ordenes.Where(x => x.id_order == id_orden).FirstOrDefault();

                    var InfoOrden = dbz.C_Delivery_Ordenes_Negocios.Where(x => x.id_orden == id_orden).FirstOrDefault();
                    var id_usuario = (int)Session["LoggedId"];
                    C_Delivery_Asignacion_Pedidos_Repartidores asig = new C_Delivery_Asignacion_Pedidos_Repartidores();
                    //asig.id_pedido = id_pedido;
                    //asig.prestar_cambio = prestar_cambio[i];
                    //asig.monto = InfoPedido.costo_envio;
                    asig.id_orden = id_orden;
                    asig.id_repartidor = validRepaZpidi.id_repartidor;
                    asig.fecha = DateTime.Now;
                    asig.monto = InfoOrden.monto;
                    asig.entregado_status = false;

                    if (id_status == 3) { asig.entregado_status = true; }

                    dbz.C_Delivery_Asignacion_Pedidos_Repartidores.Add(asig);
                    dbz.SaveChanges();


                    C_Delivery_Pagos_Repartidores pagoRepa = new C_Delivery_Pagos_Repartidores();
                    pagoRepa.id_orden = asig.id_orden;
                    pagoRepa.id_repartidor = asig.id_repartidor;
                    pagoRepa.fecha_orden = asig.fecha;

                    //SI LO PAGO EN LA ASIGNACION
                    if (id_status == 3) { pagoRepa.fecha_pago = asig.fecha; pagoRepa.id_tipo_pago = id_tipo_pago; }

                    decimal monto_repa = (decimal)InfoOrden.costo_envio;
                    try
                    {
                        int id_plataforma = (int)dbz.C_Delivery_Repartidores_Solicitudes.Where(x => x.id_repartidor == asig.id_repartidor).FirstOrDefault().C_Delivery_Repartidores_Solicitud.id_plataforma;
                        //int id_plataforma = (int)dbz.C_Delivery_Repartidores_Solicitud.Find(id_soli).id_plataforma;
                        monto_repa = Convert.ToDecimal(dbz.C_Delivery_Plataformas_Configuracion.Where(x => x.id_plataforma == id_plataforma).FirstOrDefault().porcentaje_comision_repa);
                    }
                    catch (Exception)
                    {
                        //monto_repa = 30;
                    }


                    if (asig.monto == 0) //CORTESIA
                    {
                        pagoRepa.monto = monto_repa;
                        pagoRepa.monto_orden = 0;
                    }
                    else   //PEDIDO NORMAL
                    {
                        pagoRepa.monto = monto_repa;
                        pagoRepa.monto_orden = asig.monto - monto_repa;
                    }

                    pagoRepa.id_status = id_status;
                    //pagoRepa.observaciones = obs;
                    pagoRepa.activo = true;
                    dbz.C_Delivery_Pagos_Repartidores.Add(pagoRepa);
                    dbz.SaveChanges();

                    try
                    {
                        var ordenSemaforo = dbz.C_Delivery_estatus_semaforo.Where(x => x.id_orden == id_orden).FirstOrDefault();
                        ordenSemaforo.status_semaforo = 3;
                        ordenSemaforo.descripcion_semaforo = "En Cola";
                        dbz.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        string msj = ex.ToString();
                    }

                    CambiarStatusOrdenNegocio(InfoOrden.id_orden_negocio, id_orden, 4);
                    //SI LO PAGO TERMINA EL PEDIDO
                    if (id_status == 3) { CambiarStatusOrdenNegocio(InfoOrden.id_orden_negocio, id_orden, 5); }

                }
                catch (Exception ex)
                {
                    string msj = ex.ToString();
                    //return -2;
                }
            }
            //TODO BIEN
            return 1;
        }


    }
}