using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasoEstudio_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Libro book = new Libro();

            book.Titulo = txtTitulo.Text;
            book.Autor = txtAutor.Text;
            book.AñoEdicion = Int32.Parse(txtAñoEdicion.Text);
            book.Estado = txtEstado.Text;
            book.Sumilla = txtSumilla.Text;
        }
    }
}
