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
        private int i = 0;
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

            i = dgLibro.Rows.Add();

            dgLibro.Rows[i].Cells[0].Value = txtTitulo.Text;
            dgLibro.Rows[i].Cells[1].Value = txtAutor.Text;
            dgLibro.Rows[i].Cells[2].Value = txtAñoEdicion.Text;
            dgLibro.Rows[i].Cells[3].Value = txtEstado.Text;

            txtTitulo.Clear();
            txtAutor.Clear();
            txtAñoEdicion.Clear();
            txtEstado.Clear();
            txtSumilla.Clear();

            txtTitulo.Focus();
        }

        private void dgLibro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;

            if (i != -1 && i < (dgLibro.Rows.Count - 1))
            {
                txtAutor.Text = libros.ElementAt(i).Autor;
                txtTitulo.Text = libros.ElementAt(i).Titulo;
                txtAñoEdicion.Text = libros.ElementAt(i).AñoEdicion.ToString();
                txtEstado.Text = libros.ElementAt(i).Estado;
                txtSumilla.Text = libros.ElementAt(i).Sumilla;
            }            

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (i != -1 && dgLibro.Rows.Count > 0 && i < (dgLibro.Rows.Count - 1))
            {
                libros.Remove(libros.ElementAt(i));
                dgLibro.Rows.RemoveAt(i);

                txtTitulo.Clear();
                txtAutor.Clear();
                txtAñoEdicion.Clear();
                txtEstado.Clear();
                txtSumilla.Clear();

                txtTitulo.Focus();
            } else
            {
                MessageBox.Show("No existe/n libro/s para eliminar");
            }

            
        }
    }
}
