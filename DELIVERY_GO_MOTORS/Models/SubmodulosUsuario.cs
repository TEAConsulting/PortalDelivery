﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZPIDI_PORTAL.Models
{
    public class SubmodulosUsuario
    {
        private int _id_modulo;
        private int _id_submodulo;
        private string _nombre_submodulo;
        private string _funcion;
        private string _controlador;

        public SubmodulosUsuario()
        {

        }

        public SubmodulosUsuario(int id_modulo, int id_submodulo, string nombre_submodulo, string funcion, string controlador)
        {
            this._id_modulo = id_modulo;
            this._id_submodulo = id_submodulo;
            this._nombre_submodulo = nombre_submodulo;
            this._funcion = funcion;
            this._controlador = controlador;

        }
        public int Id_modulo { get => _id_modulo; set => _id_modulo = value; }
        public int Id_submodulo { get => _id_submodulo; set => _id_submodulo = value; }
        public string Nombre_submodulo { get => _nombre_submodulo; set => _nombre_submodulo = value; }
        public string Funcion { get => _funcion; set => _funcion = value; }
        public string Controlador { get => _controlador; set => _controlador = value; }
    }
}