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
    
    public partial class C_BO_insumos_embalajes
    {
        public int id_insumo_embalaje { get; set; }
        public string nombre_embalaje { get; set; }
        public string sku_embalaje { get; set; }
        public string nombre_insumo { get; set; }
        public string sku_insumo { get; set; }
        public Nullable<decimal> cantidad { get; set; }
        public Nullable<int> id_clasificacion { get; set; }
        public Nullable<int> tipo { get; set; }
    
        public virtual C_insumo_cat C_insumo_cat { get; set; }
        public virtual C_insumo_cat C_insumo_cat1 { get; set; }
    }
}
