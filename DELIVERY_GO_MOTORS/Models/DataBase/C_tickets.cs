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
    
    public partial class C_tickets
    {
        public int id_ticket { get; set; }
        public Nullable<int> id_usuario_reporta { get; set; }
        public Nullable<int> id_ticket_subclasificacion { get; set; }
        public string codigo_sucursal { get; set; }
        public Nullable<int> id_tipo_prioridad { get; set; }
        public string observaciones { get; set; }
        public Nullable<int> id_ticket_status { get; set; }
        public Nullable<int> id_departamento { get; set; }
        public Nullable<int> id_usuario_responde { get; set; }
        public string observaciones_respuesta { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
