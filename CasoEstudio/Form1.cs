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
            string añoString = txtAñoEdicion.Text.Trim();
            string pattern = @"^\d{4}$";

            Regex miRegex = new Regex(pattern);
            MatchCollection match = miRegex.Matches(añoString);

            if (match.Count > 0)
            {
                return int.Parse(añoString);
            }

            return -1;
        }

        void ModificarFilaData(int indice, string titulo, string autor, int añoEdicion, string estado)
        {
            dgPublicaciones.Rows[indice].Cells[0].Value = titulo;
            dgPublicaciones.Rows[indice].Cells[1].Value = autor;
            dgPublicaciones.Rows[indice].Cells[2].Value = añoEdicion;
            dgPublicaciones.Rows[indice].Cells[3].Value = estado;
        }

        (string, string, int, string) ObtenerValoresCeldas(int indice)
        {
            string titulo = dgPublicaciones.Rows[indice].Cells[0].Value.ToString();
            string autor = dgPublicaciones.Rows[indice].Cells[1].Value.ToString();
            int añoEdicion = int.Parse(dgPublicaciones.Rows[indice].Cells[2].Value.ToString());
            string estado = dgPublicaciones.Rows[indice].Cells[3].Value.ToString();

            return (titulo, autor, añoEdicion, estado);
        }

        void ListarPublicacionesExistentes(IEnumerable<Publicacion> publicaciones)
        {
            dgPublicaciones.DataSource = null;
            dgPublicaciones.Rows.Clear();
            dgPublicaciones.Refresh();
            int i;

            foreach(Publicacion publicacion in publicaciones)
            {
                i = dgPublicaciones.Rows.Add();
                ModificarFilaData(i, publicacion.Titulo, publicacion.Autor, publicacion.AñoEdicion, publicacion.Estado);         
            }
        }

        int BuscarPorTitulo(string titulo)
        {
            Publicacion miPublicacion = publicaciones.Find(publ => publ.Titulo == titulo);
            int indice = publicaciones.IndexOf(miPublicacion);

            if (indice != -1)
            {
                i = 0;
                IEnumerable<Publicacion> temporal = publicaciones.Where(publ => publ.Titulo == titulo);
                ListarPublicacionesExistentes(temporal);
            }

            return indice;
        }

        int BuscarPorAutor(string autor)
        {
            Publicacion miPublicacion = publicaciones.Find(publ => publ.Autor == autor);
            int indice = publicaciones.IndexOf(miPublicacion);

            if (indice != -1)
            {
                i = 0;
                IEnumerable<Publicacion> temporal = publicaciones.Where(publ => publ.Autor == autor);
                ListarPublicacionesExistentes(temporal);
            }

            return indice;
        }

        int BuscarPorAñoEdicion(int añoEdicion)
        {
            Publicacion miPublicacion = publicaciones.Find(publ => publ.AñoEdicion == añoEdicion);
            int indice = publicaciones.IndexOf(miPublicacion);

            if (indice != -1)
            {
                i = 0;
                IEnumerable<Publicacion> temporal = publicaciones.Where(publ => publ.AñoEdicion == añoEdicion);
                ListarPublicacionesExistentes(temporal);
            }

            return indice;
        }

        int BuscarPorEstado(string estado)
        {
            Publicacion miPublicacion = publicaciones.Find(publ => publ.Estado == estado);
            int indice = publicaciones.IndexOf(miPublicacion);

            if (indice != -1)
            {
                i = 0;
                IEnumerable<Publicacion> temporal = publicaciones.Where(publ => publ.Estado == estado);
                ListarPublicacionesExistentes(temporal);
            }

            return indice;
        }

        void mostrarInfoTextBox(int i)
        {
            if (i != -1 && i < (publicaciones.Count))
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
            string titulo = txtTitulo.Text.Trim();
            string autor = txtAutor.Text.Trim();
            int añoEdicion = LeerAñoEdicion();
            string estado = txtEstado.Text.Trim();
            string sumilla = txtSumilla.Text.Trim();

            if (titulo != null && autor != null && añoEdicion != -1 && estado != null)
            {
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

                ModificarFilaData(i, titulo, autor, añoEdicion, estado);

                Limpiar();
                i = -1;
            } else
            {
                MessageBox.Show("Los campos Titulo, Autor, Año de Publicación (4 dígitos) y Estado no pueden estar vacíos");
            }

        }

        private void dgPublicacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            Console.WriteLine("===== Indice i : " + i + "======");

            if (i != -1)
            {

                (string titulo, string autor, int añoEdicion, string estado) = ObtenerValoresCeldas(i);  

                Publicacion publicacion = publicaciones.Find(publ => publ.Autor == autor && publ.Titulo == titulo && publ.AñoEdicion == añoEdicion && publ.Estado == estado);
                int indicePublicacion = publicaciones.IndexOf(publicacion);

                mostrarInfoTextBox(indicePublicacion);
            }            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indicePublicacion;

            if (i != -1 && dgPublicaciones.Rows.Count > 0 && publicaciones.Count > 0)
            {
                (string titulo, string autor, int añoEdicion, string estado) = ObtenerValoresCeldas(i);

                Publicacion publicacion = publicaciones.Find(publ => publ.Autor == autor && publ.Titulo == titulo && publ.AñoEdicion == añoEdicion && publ.Estado == estado);
                indicePublicacion = publicaciones.IndexOf(publicacion);

                publicaciones.RemoveAt(indicePublicacion);
                dgPublicaciones.Rows.RemoveAt(i);

                Limpiar();

                i--;

                if ( i != -1)
                {
                    (titulo, autor, añoEdicion, estado) = ObtenerValoresCeldas(i);

                    publicacion = publicaciones.Find(publ => publ.Autor == autor && publ.Titulo == titulo && publ.AñoEdicion == añoEdicion && publ.Estado == estado);
                    indicePublicacion = publicaciones.IndexOf(publicacion);

                    mostrarInfoTextBox(indicePublicacion);
                }

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
            string titulo = txtTitulo.Text.Trim();            
            int indiceTitulo = BuscarPorTitulo(titulo);

            if (indiceTitulo == -1)
            {
                string autor = txtAutor.Text.Trim();                    
                int indiceAutor = BuscarPorAutor(autor);

                if (indiceAutor == -1)
                {
                   int añoEdicion = LeerAñoEdicion();
                   int indiceAño = BuscarPorAñoEdicion(añoEdicion);

                      if (indiceAño == -1)
                      {
                         string estado = txtEstado.Text.Trim();
                         int indiceEstado = BuscarPorEstado(estado);

                          if (indiceEstado == -1)
                          {
                             MessageBox.Show("Oops no se encontró la Publicación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            ListarPublicacionesExistentes(publicaciones);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int indicePublicacion;

            if (i != -1 && dgPublicaciones.Rows.Count > 0 && publicaciones.Count > 0)
            {
                (string titulo, string autor, int añoEdicion, string estado) = ObtenerValoresCeldas(i);

                Publicacion publicacion = publicaciones.Find(publ => publ.Autor == autor && publ.Titulo == titulo && publ.AñoEdicion == añoEdicion && publ.Estado == estado);
                indicePublicacion = publicaciones.IndexOf(publicacion);

                //mostrarInfoTextBox(indicePublicacion);

                int tipo = cboTipo.SelectedIndex;                

                switch(tipo)
                {
                    case 0: 
                        Libro libro = (Libro) publicaciones.Find(publ => publ.Autor == autor && publ.Titulo == titulo && publ.AñoEdicion == añoEdicion && publ.Estado == estado);                        
                        libro.Titulo = txtTitulo.Text.Trim();                        
                        libro.Autor = txtAutor.Text.Trim();
                        libro.AñoEdicion = LeerAñoEdicion();
                        libro.Estado = txtEstado.Text.Trim();
                        libro.Sumilla = txtSumilla.Text.Trim();
                        ModificarFilaData(i, libro.Titulo, libro.Autor, libro.AñoEdicion, libro.Estado);                        
                        break;
                    case 1:
                        Enciclopedia enciclopedia = (Enciclopedia)publicaciones.Find(publ => publ.Autor == autor && publ.Titulo == titulo && publ.AñoEdicion == añoEdicion && publ.Estado == estado);
                        enciclopedia.Titulo = txtTitulo.Text.Trim();
                        enciclopedia.Autor = txtAutor.Text.Trim();
                        enciclopedia.AñoEdicion = LeerAñoEdicion();
                        enciclopedia.Estado = txtEstado.Text.Trim();
                        enciclopedia.Descripcion = txtSumilla.Text.Trim();
                        ModificarFilaData(i, enciclopedia.Titulo, enciclopedia.Autor, enciclopedia.AñoEdicion, enciclopedia.Estado);
                        break;
                    case 2:
                        Revista revista = (Revista) publicaciones.Find(publ => publ.Autor == autor && publ.Titulo == titulo && publ.AñoEdicion == añoEdicion && publ.Estado == estado);
                        revista.Titulo = txtTitulo.Text.Trim();
                        revista.Autor = txtAutor.Text.Trim();
                        revista.AñoEdicion = LeerAñoEdicion();
                        revista.Estado = txtEstado.Text.Trim();
                        ModificarFilaData(i, revista.Titulo, revista.Autor, revista.AñoEdicion, revista.Estado);
                        break;
                    case 3:
                        BestSeller bestSeller = (BestSeller)publicaciones.Find(publ => publ.Autor == autor && publ.Titulo == titulo && publ.AñoEdicion == añoEdicion && publ.Estado == estado);
                        bestSeller.Titulo = txtTitulo.Text.Trim();
                        bestSeller.Autor = txtAutor.Text.Trim();
                        bestSeller.AñoEdicion = LeerAñoEdicion();
                        bestSeller.Estado = txtEstado.Text.Trim();
                        bestSeller.Sumilla = txtSumilla.Text.Trim();
                        ModificarFilaData(i, bestSeller.Titulo, bestSeller.Autor, bestSeller.AñoEdicion, bestSeller.Estado);
                        break;
                    default:
                        MessageBox.Show("Oops sucedió un problema");
                        return;
                }

                i = -1;
                Limpiar();
                MessageBox.Show("Actualizado correctamente", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Busque y seleccione un registro para actualizar");
            }
        }
    }
}
