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
    
    public partial class C_Delivery_a_new_register
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_Delivery_a_new_register()
        {
            this.C_Delivery_Pagos_Plataformas = new HashSet<C_Delivery_Pagos_Plataformas>();
            this.C_Delivery_Pagos_Plataformas1 = new HashSet<C_Delivery_Pagos_Plataformas>();
            this.C_Delivery_Pre_Orders = new HashSet<C_Delivery_Pre_Orders>();
            this.C_Delivery_Usuarios_Sucursales = new HashSet<C_Delivery_Usuarios_Sucursales>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string pais { get; set; }
        public string estado { get; set; }
        public string id_local { get; set; }
        public string terminos { get; set; }
        public string score { get; set; }
        public string token { get; set; }
        public string permisos { get; set; }
        public string id_google { get; set; }
        public string id_facebook { get; set; }
        public string os { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string cp { get; set; }
        public Nullable<int> id_perfil { get; set; }
        public Nullable<int> id_usuario_imagen { get; set; }
        public Nullable<int> id_domicilio { get; set; }
        public Nullable<bool> logeado { get; set; }
        public Nullable<int> phone_pwd { get; set; }
        public string contrasena { get; set; }
        public string appname { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Delivery_Pagos_Plataformas> C_Delivery_Pagos_Plataformas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Delivery_Pagos_Plataformas> C_Delivery_Pagos_Plataformas1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Delivery_Pre_Orders> C_Delivery_Pre_Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Delivery_Usuarios_Sucursales> C_Delivery_Usuarios_Sucursales { get; set; }
    }
}
