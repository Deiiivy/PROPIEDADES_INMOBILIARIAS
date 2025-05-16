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
        public int PropiedadID { get; set; } 
        public int ClienteID { get; set; }  
        public int AgenteID { get; set; }   
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
    }
}

