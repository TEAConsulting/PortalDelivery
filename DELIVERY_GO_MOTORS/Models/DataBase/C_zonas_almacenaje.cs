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
    
    public partial class C_zonas_almacenaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_zonas_almacenaje()
        {
            this.C_almacen_insumos = new HashSet<C_almacen_insumos>();
        }
    
        public int id_zona_almacen { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string largo { get; set; }
        public string ancho { get; set; }
        public string alto { get; set; }
        public string status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_almacen_insumos> C_almacen_insumos { get; set; }
    }
}
