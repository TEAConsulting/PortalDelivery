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
    
    public partial class C_autorizaciones_tipo_permiso_roles
    {
        public int id_autorizacion_tipo_permisos_rol { get; set; }
        public Nullable<int> id_tipo_permiso { get; set; }
        public Nullable<int> id_rol { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual C_autorizacion_tipo_permisos_nip C_autorizacion_tipo_permisos_nip { get; set; }
        public virtual C_usuarios_roles C_usuarios_roles { get; set; }
    }
}
