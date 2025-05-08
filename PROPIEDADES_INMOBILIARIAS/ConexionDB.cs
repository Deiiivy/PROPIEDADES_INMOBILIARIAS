using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS
{
    public class ConexionDB
    {
        private static ConexionDB instancia;
        private SqlConnection conexion;

        private ConexionDB()
        {
            conexion = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=InmobiliariaDB;Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true");
        }

        public static ConexionDB Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ConexionDB();
                }
                return instancia;
            }
        }

        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }
    }
}
