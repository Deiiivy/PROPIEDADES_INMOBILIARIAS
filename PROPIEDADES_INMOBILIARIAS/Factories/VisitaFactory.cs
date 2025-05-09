using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROPIEDADES_INMOBILIARIAS.Models;
using System.Configuration;


    

namespace PROPIEDADES_INMOBILIARIAS.Factories
{
    public class VisitaFactory : IVisitaFactory
    {
        public Visita CrearVisita(int propiedadId, int clienteId, int agenteId, DateTime fecha, TimeSpan hora)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RealEstateDB"].ConnectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand("SP_RegistrarVisita", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PropiedadID", propiedadId);
                    cmd.Parameters.AddWithValue("@ClienteID", clienteId);
                    cmd.Parameters.AddWithValue("@AgenteID", agenteId);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Hora", hora);

                    cmd.ExecuteNonQuery();

                    return new Visita
                    {
                        PropiedadID = propiedadId,
                        ClienteID = clienteId,
                        AgenteID = agenteId,
                        Fecha = fecha,
                        Hora = hora
                    };
                }
            }
        }
    }
}
