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
    
    public partial class C_Delivery_Marca_Empresas
    {
        public int id_marca_empresa { get; set; }
        public string nombre_empresa { get; set; }
        public Nullable<int> domicilio { get; set; }
        public string nombre_representante { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<bool> status { get; set; }
    }
}
