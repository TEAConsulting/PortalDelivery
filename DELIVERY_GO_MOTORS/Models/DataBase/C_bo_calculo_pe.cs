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
    
    public partial class C_bo_calculo_pe
    {
        public string id_sucursal { get; set; }
        public string id_categoria { get; set; }
        public Nullable<int> id_bo_calculo { get; set; }
        public string id_insumo { get; set; }
        public string cant_emp { get; set; }
        public string cant_suelto { get; set; }
        public string fecha { get; set; }
        public int id_bo_calculo_pe { get; set; }
    
        public virtual C_bo_calculo C_bo_calculo { get; set; }
    }
}
