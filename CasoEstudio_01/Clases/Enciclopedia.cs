using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoEstudio_01.Clases
{
    public class Enciclopedia : Publicacion
    {
        private string descripcion;

        public Enciclopedia(string titulo, string autor, int añoEdicion, string estado, string descripcion)
            :base(titulo, autor, añoEdicion, estado)
        {
            this.Descripcion = descripcion;
        }

        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
