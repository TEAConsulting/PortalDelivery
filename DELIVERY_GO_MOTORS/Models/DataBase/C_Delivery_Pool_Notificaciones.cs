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
    
    public partial class C_Delivery_Pool_Notificaciones
    {
        public int id_pool_notificaciones { get; set; }
        public Nullable<System.DateTime> fecha_notificacion { get; set; }
        public Nullable<int> id_config_notificacion { get; set; }
        public string token { get; set; }
        public Nullable<System.DateTime> vigencia_desde { get; set; }
        public Nullable<System.DateTime> vigencia_hasta { get; set; }
        public Nullable<int> activa { get; set; }
    }
}
