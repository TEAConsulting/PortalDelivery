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
    
    public partial class C_Delivery_Comisiones
    {
        public int id_comision { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> porc_comision { get; set; }
        public Nullable<decimal> comision_fija { get; set; }
        public Nullable<decimal> costo_envio { get; set; }
        public Nullable<bool> status { get; set; }
    }
}
