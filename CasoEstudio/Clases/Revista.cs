using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoEstudio.Clases
{
    public class Revista : Publicacion
    {
        public Revista(string titulo, string autor, int añoEdicion, string estado)
            : base(titulo, autor, añoEdicion, estado)
        {

        }

        public override string obtenerInfo(string tipo)
        {
            return base.obtenerInfo(tipo);
        }
    }
}
