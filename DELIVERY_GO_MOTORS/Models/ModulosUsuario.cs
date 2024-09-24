using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZPIDI_PORTAL.Models
{
    public class ModulosUsuario
    {
        private int _id_modulo;
        private string _nombre_modulo;
        private string _icono;
        private string _color;

        public ModulosUsuario()
        {

        }

        public ModulosUsuario(int id_modulo, string nombre_modulo, string icono, string color)
        {
            this._id_modulo = id_modulo;
            this._nombre_modulo = nombre_modulo;
            this._icono = icono;
            this._color = color;

        }
        public int Id_modulo { get => _id_modulo; set => _id_modulo = value; }
        public string Nombre_modulo { get => _nombre_modulo; set => _nombre_modulo = value; }
        public string Icono { get => _icono; set => _icono = value; }
        public string Color { get => _color; set => _color = value; }
    }
}