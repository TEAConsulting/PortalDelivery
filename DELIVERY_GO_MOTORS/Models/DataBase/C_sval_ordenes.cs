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
    
    public partial class C_sval_ordenes
    {
        public int id_sval_orden { get; set; }
        public Nullable<int> id_session_ordenes { get; set; }
        public string codigo_usuario { get; set; }
        public string codigo_empresa { get; set; }
        public string codigo_sucursal { get; set; }
        public Nullable<System.DateTime> fecha_entrega { get; set; }
        public string folio { get; set; }
        public string no_comprobante { get; set; }
        public Nullable<int> id_sval_facturar { get; set; }
        public Nullable<decimal> importe_moneda_nacional { get; set; }
        public Nullable<decimal> importe_moneda_extranjera { get; set; }
        public Nullable<decimal> tipo_cambio { get; set; }
        public Nullable<decimal> importe_equivalente { get; set; }
        public Nullable<decimal> importe_documentos { get; set; }
        public Nullable<decimal> importe_otros { get; set; }
        public Nullable<decimal> importe_total { get; set; }
        public Nullable<int> id_sval_tipo_servicio { get; set; }
        public string notas_documento { get; set; }
        public Nullable<decimal> importe_diferencia { get; set; }
        public string evidencia { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
