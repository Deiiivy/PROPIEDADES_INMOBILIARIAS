using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Repositories.PermisoDecorators
{
    public static class UserSession
    {
        public static string Rol { get; set; }
        public static int? AgenteID { get; set; }
        public static int? ClienteID { get; set; }
        public static int UsuarioID { get; set; }
    }
}
