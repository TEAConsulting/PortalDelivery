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
    
    public partial class C_Delivery_Pagos_Programados_Dispersion_Plataformas
    {
        public int id_pago_plataforma { get; set; }
        public Nullable<int> id_orden_pago_g { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<decimal> saldoPagar { get; set; }
        public Nullable<decimal> adeudo_liquidaciones { get; set; }
        public Nullable<decimal> sueldo_por_reparto { get; set; }
        public Nullable<decimal> total_pagar { get; set; }
        public string num_contrato { get; set; }
        public Nullable<decimal> pctj_contrato { get; set; }
        public string cuenta { get; set; }
        public Nullable<int> id_institucion_bancaria { get; set; }
    }
}
