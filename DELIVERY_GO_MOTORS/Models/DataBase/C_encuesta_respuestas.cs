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
    
    public partial class C_encuesta_respuestas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_encuesta_respuestas()
        {
            this.C_encuestas_registro_d = new HashSet<C_encuestas_registro_d>();
        }
    
        public int id_respuesta { get; set; }
        public Nullable<int> id_pregunta_subcategoria { get; set; }
        public string respuesta { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual C_encuesta_preguntas_subcategoria C_encuesta_preguntas_subcategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_encuestas_registro_d> C_encuestas_registro_d { get; set; }
    }
}
