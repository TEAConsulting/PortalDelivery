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
    
    public partial class C_insumo_cat_log_g
    {
        public int id_insumo_cat { get; set; }
        public Nullable<System.DateTime> fecha_cambio { get; set; }
        public string sku_insumo { get; set; }
        public Nullable<int> id_usuario_cambia { get; set; }
    
        public virtual C_insumo_cat_log_g C_insumo_cat_log_g1 { get; set; }
        public virtual C_insumo_cat_log_g C_insumo_cat_log_g2 { get; set; }
    }
}
