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
    
    public partial class C_CFDI_LOGS
    {
        public int id_log { get; set; }
        public int id_pedido { get; set; }
        public int id_marca { get; set; }
        public string codigo_suc { get; set; }
        public string error { get; set; }
        public int id_cliente_cfdi { get; set; }
        public int id_estatus_logs { get; set; }
        public System.DateTime fecha { get; set; }
    }
}
