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
    
    public partial class C_Delivery_Zonas_Reparto
    {
        public int id_zona { get; set; }
        public string nombre_zona { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public Nullable<int> id_pais { get; set; }
        public Nullable<int> id_ciudad { get; set; }
        public Nullable<int> id_estado { get; set; }
        public Nullable<int> id_colonia { get; set; }
        public Nullable<decimal> ratio { get; set; }
        public string color { get; set; }
    }
}
