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
    
    public partial class C_vex_plan_meta_b3
    {
        public int id_plan_meta_b3 { get; set; }
        public Nullable<int> id_plan_meta_g { get; set; }
        public string codigo_sucursal { get; set; }
        public Nullable<int> id_dia { get; set; }
        public Nullable<System.DateTime> fecha_dia { get; set; }
        public Nullable<decimal> cantidad_meta { get; set; }
        public Nullable<decimal> porcentaje { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual C_sucursales C_sucursales { get; set; }
        public virtual C_vex_plan_meta_g C_vex_plan_meta_g { get; set; }
    }
}
