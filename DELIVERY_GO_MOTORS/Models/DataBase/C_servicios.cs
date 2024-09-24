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
    
    public partial class C_servicios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_servicios()
        {
            this.C_empresas_servicios_contratados = new HashSet<C_empresas_servicios_contratados>();
            this.C_servicios_modulos = new HashSet<C_servicios_modulos>();
            this.C_servicios_roles = new HashSet<C_servicios_roles>();
            this.C_servicios_sucursal = new HashSet<C_servicios_sucursal>();
        }
    
        public int id_servicio { get; set; }
        public string nombre_servicio { get; set; }
        public string alias_servicio { get; set; }
        public string descripcion_servicio { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<bool> activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_empresas_servicios_contratados> C_empresas_servicios_contratados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_servicios_modulos> C_servicios_modulos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_servicios_roles> C_servicios_roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_servicios_sucursal> C_servicios_sucursal { get; set; }
    }
}
