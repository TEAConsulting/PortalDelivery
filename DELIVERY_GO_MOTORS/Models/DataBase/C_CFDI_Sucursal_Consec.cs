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
    
    public partial class C_CFDI_Sucursal_Consec
    {
        public int id_suc_conse { get; set; }
        public string codigo_sucursal { get; set; }
        public string alias_sucursal { get; set; }
        public int consecutivo { get; set; }
        public Nullable<int> id_cfdi_empresa { get; set; }
    }
}
