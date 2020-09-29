using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using CasoEstudio.Clases;

namespace CasoEstudio
{
    public partial class Form1 : Form
    {
        private int i = 0;
        List<Publicacion> publicaciones = new List<Publicacion>();

        public Form1()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtTitulo.Clear();
            txtAutor.Clear();
            txtAñoEdicion.Clear();
            txtEstado.Clear();
            txtSumilla.Clear();

            txtTitulo.Focus();
        }

        int LeerAñoEdicion ()
        {
            string añoString = txtAñoEdicion.Text;
            string pattern = @"^\d{4}$";

            Regex miRegex = new Regex(pattern);
            MatchCollection match = miRegex.Matches(añoString);

            if (match.Count > 0)
            {
                return int.Parse(añoString);
            }

            return -1;
        }

        int BuscarPorTitulo(string titulo)
        {
            Publicacion miPublicacion = publicaciones.Find(publ => publ.Titulo == titulo);
            int indice = publicaciones.IndexOf(miPublicacion);

            return indice;
        }

        int BuscarPorAutor(string autor)
        {
            Publicacion miPublicacion = publicaciones.Find(publ => publ.Autor == autor);
            int indice = publicaciones.IndexOf(miPublicacion);

            return indice;
        }

        int BuscarPorAñoEdicion(int añoEdicion)
        {
            Publicacion miPublicacion = publicaciones.Find(publ => publ.AñoEdicion == añoEdicion);
            int indice = publicaciones.IndexOf(miPublicacion);

            return indice;
        }

        int BuscarPorEstado(string estado)
        {
            Publicacion miPublicacion = publicaciones.Find(publ => publ.Estado == estado);
            int indice = publicaciones.IndexOf(miPublicacion);

            return indice;
        }

        void mostrarInfoTextBox(int i)
        {
            if (i != -1 && i < (dgPublicaciones.Rows.Count))
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
                    return;
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
                    return;
                }

                if (publicaciones[i] is Revista)
                {
                    cboTipo.SelectedIndex = 2;
                    Revista miRevista = (Revista)publicaciones[i];
                    txtAutor.Text = miRevista.Autor;
                    txtTitulo.Text = miRevista.Titulo;
                    txtAñoEdicion.Text = miRevista.AñoEdicion.ToString();
                    txtEstado.Text = miRevista.Estado;
                    return;
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
                    return;
                }

            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int indice = cboTipo.SelectedIndex;
            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;
            int añoEdicion = LeerAñoEdicion();
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

            Limpiar();
        }

        private void dgPublicacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;

            mostrarInfoTextBox(i);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (i != -1 && dgPublicaciones.Rows.Count > 0 && i < (dgPublicaciones.Rows.Count) && publicaciones.Count > 0)
            {

                publicaciones.RemoveAt(i);
                dgPublicaciones.Rows.RemoveAt(i);

                Limpiar();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;            
            int indiceTitulo = BuscarPorTitulo(titulo);

            if (indiceTitulo == -1)
            {
                string autor = txtAutor.Text;                    
                int indiceAutor = BuscarPorAutor(autor);

                if (indiceAutor == -1)
                {
                   int añoEdicion = LeerAñoEdicion();
                   int indiceAño = BuscarPorAñoEdicion(añoEdicion);

                      if (indiceAño == -1)
                      {
                         string estado = txtEstado.Text;
                         int indiceEstado = BuscarPorEstado(estado);

                          if (indiceEstado == -1)
                          {
                             MessageBox.Show("Oops no se encontró el libro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             return;
                          }
                          mostrarInfoTextBox(indiceEstado);
                      }
                      mostrarInfoTextBox(indiceAño);
                }
                mostrarInfoTextBox(indiceAutor);   
             }
             mostrarInfoTextBox(indiceTitulo);
        }
    }
}
