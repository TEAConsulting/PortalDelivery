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
    
    public partial class C_Delivery_Marcas
    {
        public int id_marca { get; set; }
        public string razon_social { get; set; }
        public string nombre_comercial { get; set; }
        public Nullable<int> regimen_fiscal { get; set; }
        public string nombre_representante_legal { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<bool> status { get; set; }
        public string rfc { get; set; }
        public Nullable<int> domicilio { get; set; }
        public Nullable<int> id_comision { get; set; }
        public string categoria { get; set; }
        public Nullable<int> category_tipe { get; set; }
    }
}
