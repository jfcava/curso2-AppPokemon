using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Elemento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        

        // Sobreescribo el metodo ToString de la clase Elemento para que me muestre la descripcion
        // y no el nombre del objeto.
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
