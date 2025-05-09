using PROPIEDADES_INMOBILIARIAS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROPIEDADES_INMOBILIARIAS.Repositories
{
    public class PropiedadRepository : IPropiedadRepository
    {
        private SqlConnection conexion;

        public PropiedadRepository()
        {
            conexion = ConexionDB.Instancia.ObtenerConexion();
        }

        public void AgregarPropiedad(Propiedad propiedad)
        {
            string query = "INSERT INTO Propiedades (Direccion, Tipo, Superficie, Precio, Estado) " +
                 "VALUES (@direccion, @tipo, @superficie, @precio, @estado)";

            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@direccion", propiedad.Direccion);
            cmd.Parameters.AddWithValue("@tipo", propiedad.Tipo);
            cmd.Parameters.AddWithValue("@superficie", propiedad.Superficie);
            cmd.Parameters.AddWithValue("@precio", propiedad.Precio);
            cmd.Parameters.AddWithValue("@estado", propiedad.Estado);

            cmd.ExecuteNonQuery();
        }

        public void ActualizarPropiedad(Propiedad propiedad)
        {
            
        }

        public void EliminarPropiedad(int propiedadId)
        {
            
        }

        public List<Propiedad> ObtenerPropiedades()
        {
           
            return new List<Propiedad>();
        }
    }
}
