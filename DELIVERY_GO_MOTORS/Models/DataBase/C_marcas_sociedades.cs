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
    
    public partial class C_marcas_sociedades
    {
        public int id_marca_sociedad { get; set; }
        public Nullable<int> id_marca { get; set; }
        public Nullable<int> id_sociedad { get; set; }
    
        public virtual C_marcas_g C_marcas_g { get; set; }
        public virtual C_sociedades C_sociedades { get; set; }
    }
}
