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
    
    public partial class C_Delivery_Pagos_Servicio_Zpidi
    {
        public int id_pago_zpidi { get; set; }
        public Nullable<int> id_orden { get; set; }
        public Nullable<System.DateTime> fecha_orden { get; set; }
        public Nullable<System.DateTime> fecha_pago { get; set; }
        public Nullable<decimal> monto { get; set; }
        public Nullable<int> status { get; set; }
        public string observacion { get; set; }
        public string referecha { get; set; }
        public Nullable<decimal> porcentaje_impuesto { get; set; }
    }
}
