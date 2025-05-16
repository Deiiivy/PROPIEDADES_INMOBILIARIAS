using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; } 
        public string Nombre { get; set; } 
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Interes { get; set; } 
    }
}
