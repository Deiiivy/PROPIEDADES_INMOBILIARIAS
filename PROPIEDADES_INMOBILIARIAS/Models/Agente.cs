using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Models
{
    public class Agente
    {
        public int AgenteID { get; set; }
        public string Nombre { get; set; }
        public string ZonaEspecializacion { get; set; } // Ej: "Norte", "Centro"
        public string Telefono { get; set; }
    }
}

