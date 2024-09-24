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
    
    public partial class C_marcas_g
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_marcas_g()
        {
            this.C_autorizaciones_comercial = new HashSet<C_autorizaciones_comercial>();
            this.C_caja_comercial_movimientos = new HashSet<C_caja_comercial_movimientos>();
            this.C_direcciones_sucursales = new HashSet<C_direcciones_sucursales>();
            this.C_grupo_productos_marcas = new HashSet<C_grupo_productos_marcas>();
            this.C_HD_Ticket = new HashSet<C_HD_Ticket>();
            this.C_insumos_criticos = new HashSet<C_insumos_criticos>();
            this.C_marcas_direcciones = new HashSet<C_marcas_direcciones>();
            this.C_marcas_sociedades = new HashSet<C_marcas_sociedades>();
            this.C_pedidos = new HashSet<C_pedidos>();
            this.C_pedidos_comercial = new HashSet<C_pedidos_comercial>();
            this.C_sucursales_marcas = new HashSet<C_sucursales_marcas>();
            this.C_ventas_cierre_comercial_g = new HashSet<C_ventas_cierre_comercial_g>();
            this.C_zonas_marcas = new HashSet<C_zonas_marcas>();
        }
    
        public int id_marca { get; set; }
        public string nombre_marca { get; set; }
        public string nombre_matriz { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public string logo { get; set; }
        public string sitio_web { get; set; }
        public string color { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public Nullable<bool> status { get; set; }
        public string telefono { get; set; }
        public string logo_header { get; set; }
        public string logo_body { get; set; }
        public string logo_footer { get; set; }
        public Nullable<int> id_tipo_marca { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_autorizaciones_comercial> C_autorizaciones_comercial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_caja_comercial_movimientos> C_caja_comercial_movimientos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_direcciones_sucursales> C_direcciones_sucursales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_grupo_productos_marcas> C_grupo_productos_marcas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_HD_Ticket> C_HD_Ticket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_insumos_criticos> C_insumos_criticos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_marcas_direcciones> C_marcas_direcciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_marcas_sociedades> C_marcas_sociedades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_pedidos> C_pedidos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_pedidos_comercial> C_pedidos_comercial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_sucursales_marcas> C_sucursales_marcas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_ventas_cierre_comercial_g> C_ventas_cierre_comercial_g { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_zonas_marcas> C_zonas_marcas { get; set; }
    }
}
