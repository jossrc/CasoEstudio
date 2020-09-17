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
        List<Libro> libros = new List<Libro>();

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

            libros.Add(book);

            int n = dgLibro.Rows.Add();

            dgLibro.Rows[n].Cells[0].Value = txtTitulo.Text;
            dgLibro.Rows[n].Cells[1].Value = txtAutor.Text;
            dgLibro.Rows[n].Cells[2].Value = txtAñoEdicion.Text;
            dgLibro.Rows[n].Cells[3].Value = txtEstado.Text;
        }

        private void dgLibro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;

            if (i != -1 && i < (dgLibro.Rows.Count - 1))
            {
                txtAutor.Text = libros.ElementAt(i).Autor;
                txtTitulo.Text = libros.ElementAt(i).Titulo;
                txtAñoEdicion.Text = libros.ElementAt(i).AñoEdicion.ToString();
                txtEstado.Text = libros.ElementAt(i).Estado;
                txtSumilla.Text = libros.ElementAt(i).Sumilla;
            }            

        }
    }
}
