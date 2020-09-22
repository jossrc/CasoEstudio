using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoEstudio_01.Clases
{
    public class Revista: Publicacion
    {
        public Revista(string titulo, string autor, int añoEdicion, string estado)
            :base(titulo, autor, añoEdicion, estado)
        {

        }
    }
}
