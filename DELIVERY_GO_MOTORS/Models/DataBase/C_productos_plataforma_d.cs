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
    
    public partial class C_productos_plataforma_d
    {
        public int id_plataforma_d { get; set; }
        public string sku_g { get; set; }
        public string sku_d { get; set; }
        public Nullable<bool> activo { get; set; }
        public string codigo_sucursal { get; set; }
    
        public virtual C_productos_cat C_productos_cat { get; set; }
        public virtual C_sucursales C_sucursales { get; set; }
    }
}
