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
    
    public partial class C_ventas_cierre_d_cobros_nip
    {
        public int id_venta_cierre_d_cobros_nip { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<int> id_empleado_entrega { get; set; }
        public Nullable<int> id_empleado_recibe { get; set; }
        public string password_utilizada { get; set; }
        public string observaciones { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<int> id_venta_cierre_d { get; set; }
    
        public virtual C_empleados C_empleados { get; set; }
        public virtual C_empleados C_empleados1 { get; set; }
        public virtual C_ventas_cierre_d C_ventas_cierre_d { get; set; }
    }
}
