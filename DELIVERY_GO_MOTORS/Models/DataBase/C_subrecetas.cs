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
    
    public partial class C_subrecetas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_subrecetas()
        {
            this.C_subrecetas_d = new HashSet<C_subrecetas_d>();
        }
    
        public int id_subreceta { get; set; }
        public string sku_insumo { get; set; }
        public Nullable<decimal> cantidad { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual C_insumo_cat C_insumo_cat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_subrecetas_d> C_subrecetas_d { get; set; }
    }
}
