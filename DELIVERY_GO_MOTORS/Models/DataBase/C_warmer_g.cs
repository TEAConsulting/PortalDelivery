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
    
    public partial class C_warmer_g
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_warmer_g()
        {
            this.C_warmer_d = new HashSet<C_warmer_d>();
            this.C_warmer_preparadas = new HashSet<C_warmer_preparadas>();
        }
    
        public int id_warmer_g { get; set; }
        public string codigo_sucursal { get; set; }
        public Nullable<System.DateTime> fecha_programacion { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual C_sucursales C_sucursales { get; set; }
        public virtual C_usuarios_corporativo C_usuarios_corporativo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_warmer_d> C_warmer_d { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_warmer_preparadas> C_warmer_preparadas { get; set; }
    }
}
