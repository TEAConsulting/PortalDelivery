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
    
    public partial class C_autorizacion_respuestas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_autorizacion_respuestas()
        {
            this.C_autorizacion_solicitudes = new HashSet<C_autorizacion_solicitudes>();
            this.C_autorizaciones_comercial_d = new HashSet<C_autorizaciones_comercial_d>();
            this.C_autorizaciones_comercial_d1 = new HashSet<C_autorizaciones_comercial_d>();
        }
    
        public int id_autorizacion_respuesta { get; set; }
        public string respuesta { get; set; }
        public string color { get; set; }
        public Nullable<bool> activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizacion_solicitudes> C_autorizacion_solicitudes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizaciones_comercial_d> C_autorizaciones_comercial_d { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizaciones_comercial_d> C_autorizaciones_comercial_d1 { get; set; }
    }
}
