using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoEstudio.Clases
{
    public class Publicacion
    {
        private string titulo;
        private string autor;
        private int añoEdicion;
        private string estado;

        public Publicacion(string titulo, string autor, int añoEdicion, string estado)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.añoEdicion = añoEdicion;
            this.estado = estado;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public int AñoEdicion { get => añoEdicion; set => añoEdicion = value; }
        public string Estado { get => estado; set => estado = value; }

        public virtual String obtenerInfo(string tipo) {
            return "Tipo:" + tipo + ";\n" +
                   "Titulo: " + titulo +";\n" +
                   "Autor: " + autor + ";\n" +
                   "Año de Edición: " + añoEdicion + ";\n" +
                   "Estado: " + estado;
        }
    }
}
