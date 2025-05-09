using System.Data;
using System.Data.SqlClient;
using PROPIEDADES_INMOBILIARIAS.Models;
using System.Collections.Generic;

namespace PROPIEDADES_INMOBILIARIAS.Repositories
{
    public class PropiedadRepository : IRepository<Propiedad>
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        // Constructor con 2 parámetros (requerido por Unit of Work)
        public PropiedadRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public void Add(Propiedad propiedad)
        {
            using (var cmd = new SqlCommand("SP_InsertarPropiedad", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Direccion", propiedad.Direccion);
                cmd.Parameters.AddWithValue("@Tipo", (int)propiedad.Tipo);
                cmd.Parameters.AddWithValue("@Superficie", propiedad.Superficie);
                cmd.Parameters.AddWithValue("@Precio", propiedad.Precio);
                cmd.Parameters.AddWithValue("@Estado", (int)propiedad.Estado);
                cmd.Parameters.AddWithValue("@AgenteID", propiedad.AgenteID);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Propiedad propiedad)
        {
            using (var cmd = new SqlCommand("SP_ActualizarPropiedad", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PropiedadID", propiedad.PropiedadID);
                cmd.Parameters.AddWithValue("@Direccion", propiedad.Direccion);
                cmd.Parameters.AddWithValue("@Tipo", (int)propiedad.Tipo);
                cmd.Parameters.AddWithValue("@Superficie", propiedad.Superficie);
                cmd.Parameters.AddWithValue("@Precio", propiedad.Precio);
                cmd.Parameters.AddWithValue("@Estado", (int)propiedad.Estado);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cmd = new SqlCommand("SP_EliminarPropiedad", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PropiedadID", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Propiedad GetById(int id)
        {
            using (var cmd = new SqlCommand("SP_ObtenerPropiedadPorID", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PropiedadID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Propiedad
                        {
                            PropiedadID = (int)reader["PropiedadID"],
                            Direccion = reader["Direccion"].ToString(),
                            Tipo = (TipoPropiedad)reader["Tipo"],
                            Superficie = (double)reader["Superficie"],
                            Precio = (decimal)reader["Precio"],
                            Estado = (EstadoPropiedad)reader["Estado"],
                            AgenteID = (int)reader["AgenteID"]
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<Propiedad> GetAll()
        {
            var propiedades = new List<Propiedad>();
            using (var cmd = new SqlCommand("SP_ObtenerTodasPropiedades", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        propiedades.Add(new Propiedad
                        {
                            PropiedadID = (int)reader["PropiedadID"],
                            Direccion = reader["Direccion"].ToString(),
                            Tipo = (TipoPropiedad)reader["Tipo"],
                            Superficie = (double)reader["Superficie"],
                            Precio = (decimal)reader["Precio"],
                            Estado = (EstadoPropiedad)reader["Estado"],
                            AgenteID = (int)reader["AgenteID"]
                        });
                    }
                }
            }
            return propiedades;
        }
    }
}
