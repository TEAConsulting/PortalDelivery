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
    
    public partial class C_bo_diafestivo_ap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_bo_diafestivo_ap()
        {
            this.C_bo_porc_df = new HashSet<C_bo_porc_df>();
        }
    
        public int id_bo_df_ap { get; set; }
        public Nullable<int> id_sucursal { get; set; }
        public Nullable<int> id_bo_df { get; set; }
        public Nullable<int> id_bo_g { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual C_bo_diasfestivos C_bo_diasfestivos { get; set; }
        public virtual C_bo_g C_bo_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_bo_porc_df> C_bo_porc_df { get; set; }
    }
}
