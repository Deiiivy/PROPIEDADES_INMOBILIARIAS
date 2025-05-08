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
