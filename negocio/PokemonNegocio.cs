using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad From POKEMONS P, ELEMENTOS E, ELEMENTOS D WHERE P.IdTipo = E.Id AND D.Id = P.IdDebilidad";

                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();

                    // Empiezo a cargar el objeto con los datos del registro que me devuelve en la primera vuelta del while
                    // El cero sale del orden en el que cargue la consulta.. Select Id (0), Titulo (1), etc...
                    aux.Numero = lector.GetInt32(0);
                    // Otra manera...
                    // Esto devuelve un objeto.. por eso lo casteo como string...
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    
                    // Creao una instancia del objeto Elemento porque sino falla...
                    aux.Tipo = new Elemento();

                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];


                    // Agrego esos objetos a la lista...
                    lista.Add(aux);
                }

                // Cierro la conexion...
                conexion.Close();

                // Devuelvo la lista...
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
