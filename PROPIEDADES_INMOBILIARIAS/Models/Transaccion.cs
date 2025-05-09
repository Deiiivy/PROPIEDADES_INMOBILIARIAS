using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Models
{
    public class Transaccion
    {
        public int TransaccionID { get; set; }
        public int PropiedadID { get; set; } // FK a Propiedad
        public int ClienteID { get; set; }   // FK a Cliente
        public DateTime FechaVenta { get; set; }
        public decimal Monto { get; set; }
    }
}

