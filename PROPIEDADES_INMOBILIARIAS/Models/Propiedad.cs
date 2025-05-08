using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Models
{
    public class Propiedad
    {
        public int PropiedadID { get; set; }
        public string Direccion { get; set; }
        public string Tipo { get; set; }
        public decimal Superficie { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
    }
}
