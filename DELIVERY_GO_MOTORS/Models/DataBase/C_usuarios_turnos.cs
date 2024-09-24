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
    
    public partial class C_usuarios_turnos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_usuarios_turnos()
        {
            this.C_cajas_movimientos_cancelados = new HashSet<C_cajas_movimientos_cancelados>();
            this.C_pedidos = new HashSet<C_pedidos>();
            this.C_ventas_cierre_g = new HashSet<C_ventas_cierre_g>();
            this.C_warmer_preparadas = new HashSet<C_warmer_preparadas>();
        }
    
        public int id_turno { get; set; }
        public Nullable<int> numero_turno { get; set; }
        public Nullable<System.DateTime> fecha_apertura { get; set; }
        public Nullable<System.DateTime> fecha_cierre { get; set; }
        public string codigo_sucursal { get; set; }
        public Nullable<int> id_usuario_turno { get; set; }
        public Nullable<int> id_caja { get; set; }
        public Nullable<bool> activo { get; set; }
        public string IP_apertura { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_cajas_movimientos_cancelados> C_cajas_movimientos_cancelados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_pedidos> C_pedidos { get; set; }
        public virtual C_usuarios_corporativo C_usuarios_corporativo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_ventas_cierre_g> C_ventas_cierre_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_warmer_preparadas> C_warmer_preparadas { get; set; }
    }
}
