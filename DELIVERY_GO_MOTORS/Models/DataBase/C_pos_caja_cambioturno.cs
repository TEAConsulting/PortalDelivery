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
    
    public partial class C_pos_caja_cambioturno
    {
        public int id_caja_ct { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string hora { get; set; }
        public Nullable<int> usuario_entrega { get; set; }
        public Nullable<int> usuario_recibe { get; set; }
        public Nullable<decimal> venta_efectivo { get; set; }
        public Nullable<decimal> fondo_caja { get; set; }
        public Nullable<decimal> retiros_efectivo { get; set; }
        public Nullable<decimal> otros_retiros { get; set; }
        public Nullable<decimal> total_efectivo { get; set; }
        public Nullable<decimal> efectivo_recibido { get; set; }
        public Nullable<decimal> resultante { get; set; }
        public Nullable<decimal> insumos_sistema { get; set; }
        public Nullable<decimal> insumos_captura { get; set; }
        public Nullable<decimal> insumos_diferencia { get; set; }
        public Nullable<decimal> insumos_resultante { get; set; }
        public Nullable<int> id_terminal { get; set; }
    }
}
