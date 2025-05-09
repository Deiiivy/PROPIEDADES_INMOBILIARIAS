using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROPIEDADES_INMOBILIARIAS.Models;
using PROPIEDADES_INMOBILIARIAS.Repositories;

namespace PROPIEDADES_INMOBILIARIAS.Factories
{
    public class TransaccionFactory : ITransaccionFactory
    {
        public Transaccion CrearTransaccion(int propiedadId, int clienteId, decimal monto)
        {
            using (var cmd = new SqlCommand("SP_RegistrarTransaccion", DatabaseConnection.Instance.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PropiedadID", propiedadId);
                cmd.Parameters.AddWithValue("@ClienteID", clienteId);
                cmd.Parameters.AddWithValue("@Monto", monto);

                cmd.ExecuteNonQuery();

                return new Transaccion
                {
                    PropiedadID = propiedadId,
                    ClienteID = clienteId,
                    FechaVenta = DateTime.Now,
                    Monto = monto
                };
            }
        }
    }
}
