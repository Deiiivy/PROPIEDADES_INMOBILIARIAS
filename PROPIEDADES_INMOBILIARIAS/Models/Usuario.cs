using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Rol { get; set; } // Admin, Agente, Cliente
        public int? AgenteID { get; set; } // Solo para agentes
        public int? ClienteID { get; set; } // Solo para clientes
    }
}
