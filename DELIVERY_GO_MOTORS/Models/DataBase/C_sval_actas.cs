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
    
    public partial class C_sval_actas
    {
        public Nullable<int> id_sval_acta_orden { get; set; }
        public Nullable<int> ide_sval_orden { get; set; }
        public Nullable<System.DateTime> fecha_acta { get; set; }
        public Nullable<int> id_ciudad { get; set; }
        public Nullable<int> id_empresa_servicios { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public Nullable<int> id_sucursal { get; set; }
        public string id_sellos { get; set; }
        public string No_comprobante { get; set; }
        public Nullable<decimal> efectivo { get; set; }
        public string documentos { get; set; }
        public Nullable<int> id_sval_subservicio { get; set; }
        public Nullable<decimal> importe_diferencia { get; set; }
        public string divisas { get; set; }
        public Nullable<decimal> faltante_fisico { get; set; }
        public Nullable<int> piezas_sin_valor { get; set; }
        public Nullable<decimal> sobrante_fisico { get; set; }
        public decimal presuntamente_falso { get; set; }
        public Nullable<int> id_cajero_responsable { get; set; }
        public Nullable<int> id_supervisor { get; set; }
        public Nullable<int> id_seguridad { get; set; }
    }
}
