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

using CasoEstudio.Clases;

namespace CasoEstudio
{
    public partial class Form1 : Form
    {
        private int i = 0;
        ArrayList publicaciones = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
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
                if (publicaciones[i] is Libro)
                {
                    cboTipo.SelectedIndex = 0;
                    Libro miLibro = (Libro)publicaciones[i];
                    txtAutor.Text = miLibro.Autor;
                    txtTitulo.Text = miLibro.Titulo;
                    txtAñoEdicion.Text = miLibro.AñoEdicion.ToString();
                    txtEstado.Text = miLibro.Estado;
                    txtSumilla.Text = miLibro.Sumilla;
                }

                if (publicaciones[i] is Enciclopedia)
                {
                    cboTipo.SelectedIndex = 1;
                    Enciclopedia miEnciclopedia = (Enciclopedia)publicaciones[i];
                    txtAutor.Text = miEnciclopedia.Autor;
                    txtTitulo.Text = miEnciclopedia.Titulo;
                    txtAñoEdicion.Text = miEnciclopedia.AñoEdicion.ToString();
                    txtEstado.Text = miEnciclopedia.Estado;
                    txtSumilla.Text = miEnciclopedia.Descripcion;
                }

                if (publicaciones[i] is Revista)
                {
                    cboTipo.SelectedIndex = 2;
                    Revista miRevista = (Revista)publicaciones[i];
                    txtAutor.Text = miRevista.Autor;
                    txtTitulo.Text = miRevista.Titulo;
                    txtAñoEdicion.Text = miRevista.AñoEdicion.ToString();
                    txtEstado.Text = miRevista.Estado;
                }

                if (publicaciones[i] is BestSeller)
                {
                    cboTipo.SelectedIndex = 3;
                    BestSeller miBestSeller = (BestSeller)publicaciones[i];
                    txtAutor.Text = miBestSeller.Autor;
                    txtTitulo.Text = miBestSeller.Titulo;
                    txtAñoEdicion.Text = miBestSeller.AñoEdicion.ToString();
                    txtEstado.Text = miBestSeller.Estado;
                    txtSumilla.Text = miBestSeller.Sumilla;
                }

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (i != -1 && dgPublicaciones.Rows.Count > 0 && i < (dgPublicaciones.Rows.Count - 1) && publicaciones.Count > 0)
            {

                publicaciones.RemoveAt(i);
                dgPublicaciones.Rows.RemoveAt(i);

                txtTitulo.Clear();
                txtAutor.Clear();
                txtAñoEdicion.Clear();
                txtEstado.Clear();
                txtSumilla.Clear();

                txtTitulo.Focus();
            }
            else
            {
                MessageBox.Show("No existe/n Publicacion/es para eliminar");
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cboTipo.SelectedIndex;
            string tipo = cboTipo.SelectedItem.ToString();

            switch (indice)
            {
                case 0:
                    lblSumilla.Visible = true;
                    txtSumilla.Visible = true;
                    lblSumilla.Text = "Sumilla";
                    btnRegistrar.Text = "Registrar " + tipo;
                    break;
                case 1:
                    lblSumilla.Visible = true;
                    txtSumilla.Visible = true;
                    lblSumilla.Text = "Descripción";
                    btnRegistrar.Text = "Registrar " + tipo;
                    break;
                case 2:
                    lblSumilla.Visible = false;
                    txtSumilla.Visible = false;
                    btnRegistrar.Text = "Registrar " + tipo;
                    break;
                case 3:
                    lblSumilla.Visible = true;
                    txtSumilla.Visible = true;
                    lblSumilla.Text = "Sumilla";
                    btnRegistrar.Text = "Registrar " + tipo;
                    break;
            }

        }

    }
}
