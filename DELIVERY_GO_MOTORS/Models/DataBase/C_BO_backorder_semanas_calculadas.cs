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
    
    public partial class C_BO_backorder_semanas_calculadas
    {
        public int id_backorder_semana { get; set; }
        public Nullable<int> id_backorder { get; set; }
        public string rango_semana { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual C_BO_backorder C_BO_backorder { get; set; }
    }
}
