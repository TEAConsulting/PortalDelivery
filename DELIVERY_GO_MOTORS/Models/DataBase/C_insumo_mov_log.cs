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
    
    public partial class C_insumo_mov_log
    {
        public int id_insumo_mov_log { get; set; }
        public string codigo_sucursal { get; set; }
        public Nullable<int> id_insumo_mov { get; set; }
        public Nullable<int> id_usuario_cambio { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
