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
    
    public partial class C_HD_CorreosDepartamentos
    {
        public int id_HD_departamentos { get; set; }
        public Nullable<int> id_usuario_corporativo { get; set; }
        public string correo { get; set; }
        public Nullable<int> id_area { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual C_HD_area C_HD_area { get; set; }
        public virtual C_usuarios_corporativo C_usuarios_corporativo { get; set; }
    }
}
