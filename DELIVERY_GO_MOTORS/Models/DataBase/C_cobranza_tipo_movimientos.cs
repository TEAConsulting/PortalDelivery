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
    
    public partial class C_cobranza_tipo_movimientos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_cobranza_tipo_movimientos()
        {
            this.C_administrador_valores_g = new HashSet<C_administrador_valores_g>();
        }
    
        public int id_cobranza_tipo_mov { get; set; }
        public string tipo_movimiento { get; set; }
        public Nullable<bool> cargo_abono { get; set; }
        public Nullable<bool> activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_administrador_valores_g> C_administrador_valores_g { get; set; }
    }
}
