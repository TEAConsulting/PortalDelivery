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
    
    public partial class C_usuarios_subzonas
    {
        public int id_usuario_subzona { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<int> id_subzona { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual C_subzonas C_subzonas { get; set; }
        public virtual C_usuarios_corporativo C_usuarios_corporativo { get; set; }
    }
}
