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
    
    public partial class C_bonos_sucursales_g_roles
    {
        public int id_bono_sucursales_roles { get; set; }
        public Nullable<int> id_bonos_sucursales_g { get; set; }
        public Nullable<int> id_rol { get; set; }
        public Nullable<int> descripcion_rol { get; set; }
        public Nullable<decimal> monto { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<int> id_usuario_registra { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
