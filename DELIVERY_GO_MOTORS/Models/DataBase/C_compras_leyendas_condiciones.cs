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
    
    public partial class C_compras_leyendas_condiciones
    {
        public int id_leyendas_condiciones { get; set; }
        public Nullable<int> id_tipo_leyenda { get; set; }
        public Nullable<int> id_ubicacion_hoja { get; set; }
        public string leyenda { get; set; }
        public Nullable<bool> activa { get; set; }
    }
}
