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
    
    public partial class C_menu
    {
        public int id_menu { get; set; }
        public Nullable<int> id_seccion_menu { get; set; }
        public Nullable<int> id_marca { get; set; }
        public string url_imagen { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
