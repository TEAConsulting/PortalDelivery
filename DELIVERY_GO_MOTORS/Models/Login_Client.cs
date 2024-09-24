using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZPIDI_PORTAL.Models
{
    public class Login_Client
    {
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public string Activo { get; set; }
        public JsonArray data { get; set; }
    }


    public class DataUser
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string foto { get; set; }
        public string tokken { get; set; }
        public int logeado { get; set; }
        public int id_perfil { get; set; }
        public string perfil { get; set; }
        public int id_google { get; set; }
    }

}