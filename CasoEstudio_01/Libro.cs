using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoEstudio_01
{
    class Libro
    {
        // Atributos
        private string titulo;
        private string autor;
        private int añoEdicion;
        private string estado;
        private string sumilla;

        // Propiedades
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public int AñoEdicion { get => añoEdicion; set => añoEdicion = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Sumilla { get => sumilla; set => sumilla = value; }
    }
}
