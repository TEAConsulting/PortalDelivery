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
    
    public partial class C_Compac_Empleados_a_Procesar
    {
        public int idCargaCompaq { get; set; }
        public Nullable<int> empleadoid { get; set; }
        public Nullable<int> numero { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public Nullable<int> idpuesto { get; set; }
        public Nullable<int> iddepartamento { get; set; }
        public Nullable<System.DateTime> fecha_ingreso { get; set; }
        public string sucursal { get; set; }
        public string nombre_puesto { get; set; }
        public string curp { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public string estatus { get; set; }
        public Nullable<System.DateTime> fecha_baja { get; set; }
        public string causa_baja { get; set; }
        public string usuario { get; set; }
    }
}
