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
    
    public partial class C_produccion_generada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_produccion_generada()
        {
            this.C_produccion_generada_d = new HashSet<C_produccion_generada_d>();
        }
    
        public int id_produccion_generada { get; set; }
        public string codigo_sucursal { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<System.DateTime> fecha_hora { get; set; }
        public Nullable<int> hora { get; set; }
        public Nullable<bool> activo { get; set; }
        public string observaciones { get; set; }
    
        public virtual C_sucursales C_sucursales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_produccion_generada_d> C_produccion_generada_d { get; set; }
    }
}
