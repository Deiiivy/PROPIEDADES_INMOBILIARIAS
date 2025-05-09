using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Models
{
    public class Visita
    {
        public int VisitaID { get; set; }
        public int PropiedadID { get; set; } // FK a Propiedad
        public int ClienteID { get; set; }    // FK a Cliente
        public int AgenteID { get; set; }     // FK a Agente
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }
}

