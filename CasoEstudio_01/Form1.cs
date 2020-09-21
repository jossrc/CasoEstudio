using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CasoEstudio_01.Clases;

namespace CasoEstudio_01
{
    public partial class Form1 : Form
    {
        private int i = 0;
        ArrayList publicaciones = new ArrayList();
        List<Libro> libros = new List<Libro>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indice = cboTipo.SelectedIndex;
            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;
            int añoEdicion = int.Parse(txtAñoEdicion.Text);
            string estado = txtEstado.Text;
            string sumilla = txtSumilla.Text;

            switch (indice)
            {
                case 0:
                    Libro libro = new Libro(titulo, autor, añoEdicion, estado, sumilla);
                    publicaciones.Add(libro);
                    break;
                case 1:
                    Enciclopedia enciclopedia = new Enciclopedia(titulo, autor, añoEdicion, estado, sumilla);
                    publicaciones.Add(enciclopedia);
                    break;
                case 2:
                    Revista revista = new Revista(titulo, autor, añoEdicion, estado);
                    publicaciones.Add(revista);
                    break;
                case 3:
                    BestSeller bestSeller = new BestSeller(titulo, autor, añoEdicion, estado, sumilla);
                    publicaciones.Add(bestSeller);
                    break;
                default:
                    MessageBox.Show("Seleccione un tipo");
                    return;
            }

            i = dgPublicaciones.Rows.Add();

            dgPublicaciones.Rows[i].Cells[0].Value = txtTitulo.Text;
            dgPublicaciones.Rows[i].Cells[1].Value = txtAutor.Text;
            dgPublicaciones.Rows[i].Cells[2].Value = txtAñoEdicion.Text;
            dgPublicaciones.Rows[i].Cells[3].Value = txtEstado.Text;

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

            if (i != -1 && i < (dgPublicaciones.Rows.Count - 1))
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
            if (i != -1 && dgPublicaciones.Rows.Count > 0 && i < (dgPublicaciones.Rows.Count - 1))
            {
                libros.Remove(libros.ElementAt(i));
                dgPublicaciones.Rows.RemoveAt(i);

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

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cboTipo.SelectedIndex;
            string tipo = cboTipo.SelectedItem.ToString();

            switch(indice)
            {
                case 0 :
                    lblSumilla.Visible = true;
                    txtSumilla.Visible = true;
                    lblSumilla.Text = "Sumilla";
                    btnRegistrarLibro.Text = "Registrar " + tipo;
                    break;
                case 1:
                    lblSumilla.Visible = true;
                    txtSumilla.Visible = true;
                    lblSumilla.Text = "Descripción";
                    btnRegistrarLibro.Text = "Registrar " + tipo;
                    break;
                case 2: 
                    lblSumilla.Visible = false;
                    txtSumilla.Visible = false;
                    btnRegistrarLibro.Text = "Registrar " + tipo;
                    break;
                case 3:
                    lblSumilla.Visible = true;
                    txtSumilla.Visible = true;
                    lblSumilla.Text = "Sumilla";
                    btnRegistrarLibro.Text = "Registrar " + tipo;
                    break;
            }

        }
    }
}
