using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// MODELO EN CAPAS
// Hago la llamada a las dos clases que estan en distintos proyectos creados, dominio y negocio
// Para esto, las clases DEBEN ser public
using dominio;
using negocio;

namespace appPokemon
{
    public partial class Form1 : Form
    {
        // Declaro lista de Pokemon...
        private List<Pokemon> listaPokemons;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Creo una variable de tipo PokemonNegocio con la lista generada por el objeto..
            PokemonNegocio negocio = new PokemonNegocio();

            // Guardo la lista generada por el metodo listar() del objero PokemonNegocio
            listaPokemons = negocio.listar();

            // Al Data Grid View le cargo la lista..
            dgvBaseDatos.DataSource = listaPokemons;

            // Hago invisible la columna UrlImagen...
            dgvBaseDatos.Columns["UrlImagen"].Visible = false;


            // Uso metodo para cargar imagen en el PictureBox...
            cargarImagen(listaPokemons[0].UrlImagen);


        }

        private void dgvBaseDatos_SelectionChanged(object sender, EventArgs e)
        {
            // Actualizo la imagen del PictureBox con el objeto seleccionado en el DataGridView
            Pokemon seleccionado = (Pokemon)dgvBaseDatos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }

        
        // Metodo para cargar la imagen al PictureBox, con el try catch puedo cargar imagen en blanco
        // en caso de que un objeto no tenga Url, o no funcione y no se rompa.
        private void cargarImagen(string imagen)
        {
            try
            {
                pbPokemon.Load(imagen);
            }
            catch (Exception ex)
            {

                pbPokemon.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoPokemon nuevoPokemon = new frmNuevoPokemon();
            nuevoPokemon.ShowDialog();
        }
    }
}
