using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Models
{
    public class Propiedad
    {
        public string Zona { get; set; }
        
        public int PropiedadID { get; set; }

       
        public string Direccion { get; set; }

        
        public TipoPropiedad Tipo { get; set; }

     
        public double Superficie { get; set; }


        public decimal Precio { get; set; }


        public EstadoPropiedad Estado { get; set; }


        public int AgenteID { get; set; }


    }
}

