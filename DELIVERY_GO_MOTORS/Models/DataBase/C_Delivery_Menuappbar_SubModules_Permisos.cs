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
    
    public partial class C_Delivery_Menuappbar_SubModules_Permisos
    {
        public int id_modulo_sub_permiso { get; set; }
        public Nullable<int> id_modulo_sub { get; set; }
        public Nullable<int> id_rol { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual C_Delivery_Menuappbar_SubModules C_Delivery_Menuappbar_SubModules { get; set; }
    }
}
