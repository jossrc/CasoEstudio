using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasoEstudio.Clases
{
    public class BestSeller : Publicacion
    {
        private string sumilla;

        public BestSeller(string titulo, string autor, int añoEdicion, string estado, string sumilla)
            : base(titulo, autor, añoEdicion, estado)
        {
            this.Sumilla = sumilla;
        }

        public string Sumilla { get => sumilla; set => sumilla = value; }

        public override string obtenerInfo(string tipo)
        {
            return base.obtenerInfo(tipo) + ";\n" +
                   "Sumilla: " + sumilla;
        }
    }
}
