//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZPIDI_PORTAL.Models.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class C_usuarios_corporativo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_usuarios_corporativo()
        {
            this.C_agenda = new HashSet<C_agenda>();
            this.C_agenda_d = new HashSet<C_agenda_d>();
            this.C_autorizacion_mensajeria = new HashSet<C_autorizacion_mensajeria>();
            this.C_autorizacion_solicitudes = new HashSet<C_autorizacion_solicitudes>();
            this.C_autorizacion_solicitudes1 = new HashSet<C_autorizacion_solicitudes>();
            this.C_autorizacion_usuarios = new HashSet<C_autorizacion_usuarios>();
            this.C_autorizaciones_comercial = new HashSet<C_autorizaciones_comercial>();
            this.C_autorizaciones_comercial1 = new HashSet<C_autorizaciones_comercial>();
            this.C_autorizaciones_comercial_d = new HashSet<C_autorizaciones_comercial_d>();
            this.C_BO_backorder = new HashSet<C_BO_backorder>();
            this.C_BO_backorder_entregas = new HashSet<C_BO_backorder_entregas>();
            this.C_BO_backorder_log_cambios_entregas = new HashSet<C_BO_backorder_log_cambios_entregas>();
            this.C_caja_comercial_movimientos = new HashSet<C_caja_comercial_movimientos>();
            this.C_caja_comercial_movimientos1 = new HashSet<C_caja_comercial_movimientos>();
            this.C_cajas_movimientos_cancelados = new HashSet<C_cajas_movimientos_cancelados>();
            this.C_cajas_movimientos_cancelados1 = new HashSet<C_cajas_movimientos_cancelados>();
            this.C_cobranza_corte_g = new HashSet<C_cobranza_corte_g>();
            this.C_conciliacion_cobro_d = new HashSet<C_conciliacion_cobro_d>();
            this.C_conciliacion_cobro_g = new HashSet<C_conciliacion_cobro_g>();
            this.C_credito_distribuidor_empleados = new HashSet<C_credito_distribuidor_empleados>();
            this.C_credito_distribuidor_empleados1 = new HashSet<C_credito_distribuidor_empleados>();
            this.C_credito_movimientos_wallet = new HashSet<C_credito_movimientos_wallet>();
            this.C_Delivery_Pre_Orders = new HashSet<C_Delivery_Pre_Orders>();
            this.C_empleados_cargos = new HashSet<C_empleados_cargos>();
            this.C_encuestas = new HashSet<C_encuestas>();
            this.C_encuestas_registro_d = new HashSet<C_encuestas_registro_d>();
            this.C_encuestas_registro_g = new HashSet<C_encuestas_registro_g>();
            this.C_grupo_difusion = new HashSet<C_grupo_difusion>();
            this.C_HD_CorreosDepartamentos = new HashSet<C_HD_CorreosDepartamentos>();
            this.C_HD_grupos_personas = new HashSet<C_HD_grupos_personas>();
            this.C_HD_Ticket = new HashSet<C_HD_Ticket>();
            this.C_HD_ticket_detalle = new HashSet<C_HD_ticket_detalle>();
            this.C_HD_valoracion = new HashSet<C_HD_valoracion>();
            this.C_insumo_mov_masivo = new HashSet<C_insumo_mov_masivo>();
            this.C_insumos_criticos = new HashSet<C_insumos_criticos>();
            this.C_inventario_suc_g = new HashSet<C_inventario_suc_g>();
            this.C_log_modificaciones_g = new HashSet<C_log_modificaciones_g>();
            this.C_log_servicio_delivery = new HashSet<C_log_servicio_delivery>();
            this.C_mensajeria = new HashSet<C_mensajeria>();
            this.C_mesas = new HashSet<C_mesas>();
            this.C_pedidos = new HashSet<C_pedidos>();
            this.C_pedidos_comercial = new HashSet<C_pedidos_comercial>();
            this.C_pedidos_productos_cancelados = new HashSet<C_pedidos_productos_cancelados>();
            this.C_plan_comercial_facturacion = new HashSet<C_plan_comercial_facturacion>();
            this.C_productos_cat_log_g = new HashSet<C_productos_cat_log_g>();
            this.C_Repartidores_Sucursales = new HashSet<C_Repartidores_Sucursales>();
            this.C_Repartidores_Sucursales1 = new HashSet<C_Repartidores_Sucursales>();
            this.C_solicitudes_repartidor = new HashSet<C_solicitudes_repartidor>();
            this.C_solicitudes_repartidor1 = new HashSet<C_solicitudes_repartidor>();
            this.C_solicitudes_repartidor2 = new HashSet<C_solicitudes_repartidor>();
            this.C_sucursales_preparadas = new HashSet<C_sucursales_preparadas>();
            this.C_tracking_status_log = new HashSet<C_tracking_status_log>();
            this.C_usuarios_delivery = new HashSet<C_usuarios_delivery>();
            this.C_usuarios_mesas = new HashSet<C_usuarios_mesas>();
            this.C_usuarios_servicios = new HashSet<C_usuarios_servicios>();
            this.C_usuarios_subzonas = new HashSet<C_usuarios_subzonas>();
            this.C_usuarios_sucursales = new HashSet<C_usuarios_sucursales>();
            this.C_usuarios_sucursales1 = new HashSet<C_usuarios_sucursales>();
            this.C_usuarios_turnos = new HashSet<C_usuarios_turnos>();
            this.C_usuarios_turnos_comercial = new HashSet<C_usuarios_turnos_comercial>();
            this.C_usuarios_zonas = new HashSet<C_usuarios_zonas>();
            this.C_ventas_cierre_comercial_g = new HashSet<C_ventas_cierre_comercial_g>();
            this.C_ventas_cierre_g = new HashSet<C_ventas_cierre_g>();
            this.C_ventas_pedido_comercial = new HashSet<C_ventas_pedido_comercial>();
            this.C_ventas_pedido_comercial1 = new HashSet<C_ventas_pedido_comercial>();
            this.C_vex_plan_meta_g = new HashSet<C_vex_plan_meta_g>();
            this.C_warmer_g = new HashSet<C_warmer_g>();
            this.C_warmer_preparadas = new HashSet<C_warmer_preparadas>();
            this.CS_sesiones_usuarios = new HashSet<CS_sesiones_usuarios>();
            this.C_usuarios_sucursales_extra = new HashSet<C_usuarios_sucursales_extra>();
            this.C_usuarios_roles_multi = new HashSet<C_usuarios_roles_multi>();
        }
    
        public int id_usuario_corporativo { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public Nullable<int> id_empleado { get; set; }
        public Nullable<int> id_usuario_tipo { get; set; }
        public Nullable<int> id_rol { get; set; }
        public Nullable<int> id_rol_backend { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> fecha_alta { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<bool> dispositivo_movil { get; set; }
        public Nullable<bool> usuario_default { get; set; }
        public Nullable<bool> gerente { get; set; }
        public Nullable<int> puesto_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_agenda> C_agenda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_agenda_d> C_agenda_d { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizacion_mensajeria> C_autorizacion_mensajeria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizacion_solicitudes> C_autorizacion_solicitudes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizacion_solicitudes> C_autorizacion_solicitudes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizacion_usuarios> C_autorizacion_usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizaciones_comercial> C_autorizaciones_comercial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizaciones_comercial> C_autorizaciones_comercial1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizaciones_comercial_d> C_autorizaciones_comercial_d { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_BO_backorder> C_BO_backorder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_BO_backorder_entregas> C_BO_backorder_entregas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_BO_backorder_log_cambios_entregas> C_BO_backorder_log_cambios_entregas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_caja_comercial_movimientos> C_caja_comercial_movimientos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_caja_comercial_movimientos> C_caja_comercial_movimientos1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_cajas_movimientos_cancelados> C_cajas_movimientos_cancelados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_cajas_movimientos_cancelados> C_cajas_movimientos_cancelados1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_cobranza_corte_g> C_cobranza_corte_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_conciliacion_cobro_d> C_conciliacion_cobro_d { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_conciliacion_cobro_g> C_conciliacion_cobro_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_credito_distribuidor_empleados> C_credito_distribuidor_empleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_credito_distribuidor_empleados> C_credito_distribuidor_empleados1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_credito_movimientos_wallet> C_credito_movimientos_wallet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Delivery_Pre_Orders> C_Delivery_Pre_Orders { get; set; }
        public virtual C_empleados C_empleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_empleados_cargos> C_empleados_cargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_encuestas> C_encuestas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_encuestas_registro_d> C_encuestas_registro_d { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_encuestas_registro_g> C_encuestas_registro_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_grupo_difusion> C_grupo_difusion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_HD_CorreosDepartamentos> C_HD_CorreosDepartamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_HD_grupos_personas> C_HD_grupos_personas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_HD_Ticket> C_HD_Ticket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_HD_ticket_detalle> C_HD_ticket_detalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_HD_valoracion> C_HD_valoracion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_insumo_mov_masivo> C_insumo_mov_masivo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_insumos_criticos> C_insumos_criticos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_inventario_suc_g> C_inventario_suc_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_log_modificaciones_g> C_log_modificaciones_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_log_servicio_delivery> C_log_servicio_delivery { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_mensajeria> C_mensajeria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_mesas> C_mesas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_pedidos> C_pedidos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_pedidos_comercial> C_pedidos_comercial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_pedidos_productos_cancelados> C_pedidos_productos_cancelados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_plan_comercial_facturacion> C_plan_comercial_facturacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_productos_cat_log_g> C_productos_cat_log_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Repartidores_Sucursales> C_Repartidores_Sucursales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Repartidores_Sucursales> C_Repartidores_Sucursales1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_solicitudes_repartidor> C_solicitudes_repartidor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_solicitudes_repartidor> C_solicitudes_repartidor1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_solicitudes_repartidor> C_solicitudes_repartidor2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_sucursales_preparadas> C_sucursales_preparadas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_tracking_status_log> C_tracking_status_log { get; set; }
        public virtual C_usuarios_roles C_usuarios_roles { get; set; }
        public virtual C_usuarios_roles C_usuarios_roles1 { get; set; }
        public virtual C_usuarios_tipo C_usuarios_tipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_delivery> C_usuarios_delivery { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_mesas> C_usuarios_mesas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_servicios> C_usuarios_servicios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_subzonas> C_usuarios_subzonas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_sucursales> C_usuarios_sucursales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_sucursales> C_usuarios_sucursales1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_turnos> C_usuarios_turnos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_turnos_comercial> C_usuarios_turnos_comercial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_zonas> C_usuarios_zonas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_ventas_cierre_comercial_g> C_ventas_cierre_comercial_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_ventas_cierre_g> C_ventas_cierre_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_ventas_pedido_comercial> C_ventas_pedido_comercial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_ventas_pedido_comercial> C_ventas_pedido_comercial1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_vex_plan_meta_g> C_vex_plan_meta_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_warmer_g> C_warmer_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_warmer_preparadas> C_warmer_preparadas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CS_sesiones_usuarios> CS_sesiones_usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_sucursales_extra> C_usuarios_sucursales_extra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_usuarios_roles_multi> C_usuarios_roles_multi { get; set; }
    }
}
