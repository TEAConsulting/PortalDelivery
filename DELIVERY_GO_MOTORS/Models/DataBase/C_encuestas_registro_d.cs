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
    
    public partial class C_encuestas_registro_d
    {
        public int id_encuesta_registro_d { get; set; }
        public Nullable<int> id_encuesta_registro_g { get; set; }
        public Nullable<int> id_pregunta { get; set; }
        public Nullable<int> id_respuesta { get; set; }
        public string otra_respuesta { get; set; }
        public Nullable<int> id_usuario_registra { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual C_encuesta_preguntas C_encuesta_preguntas { get; set; }
        public virtual C_encuesta_respuestas C_encuesta_respuestas { get; set; }
        public virtual C_encuestas_registro_g C_encuestas_registro_g { get; set; }
        public virtual C_usuarios_corporativo C_usuarios_corporativo { get; set; }
    }
}
