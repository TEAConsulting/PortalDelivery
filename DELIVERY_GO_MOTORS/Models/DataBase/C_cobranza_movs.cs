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
    
    public partial class C_cobranza_movs
    {
        public int id_cobranza_movs { get; set; }
        public Nullable<System.DateTime> fecha_p_desde { get; set; }
        public Nullable<System.DateTime> fecha_p_hasta { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<int> id_empleado { get; set; }
        public Nullable<decimal> monto { get; set; }
        public Nullable<bool> cargo_abono { get; set; }
        public Nullable<int> id_tipo_movimiento { get; set; }
        public Nullable<int> id_usuario_registra { get; set; }
        public Nullable<int> id_estatus_transaccion { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
