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
    
    public partial class C_Delivery_Menuappbar_ModulesWeb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_Delivery_Menuappbar_ModulesWeb()
        {
            this.C_Delivery_Menuappbar_SubModules = new HashSet<C_Delivery_Menuappbar_SubModules>();
        }
    
        public int id_modulo_web { get; set; }
        public string nombre { get; set; }
        public string icono { get; set; }
        public string color { get; set; }
        public Nullable<bool> activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Delivery_Menuappbar_SubModules> C_Delivery_Menuappbar_SubModules { get; set; }
    }
}
