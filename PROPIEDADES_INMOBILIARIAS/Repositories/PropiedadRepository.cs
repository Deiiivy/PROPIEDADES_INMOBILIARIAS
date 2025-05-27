using System.Data;
using System.Data.SqlClient;
using PROPIEDADES_INMOBILIARIAS.Models;
using System.Collections.Generic;
using System;

namespace PROPIEDADES_INMOBILIARIAS.Repositories
{
    public class PropiedadRepository : IRepository<Propiedad>
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

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
                cmd.Parameters.AddWithValue("@Tipo", propiedad.Tipo.ToString());
                cmd.Parameters.AddWithValue("@Superficie", propiedad.Superficie);
                cmd.Parameters.AddWithValue("@Precio", propiedad.Precio);
                cmd.Parameters.AddWithValue("@Estado", propiedad.Estado.ToString());
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
                cmd.Parameters.AddWithValue("@Tipo", propiedad.Tipo.ToString());
                cmd.Parameters.AddWithValue("@Superficie", propiedad.Superficie);
                cmd.Parameters.AddWithValue("@Precio", propiedad.Precio);
                cmd.Parameters.AddWithValue("@Estado", propiedad.Estado.ToString());
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
                            Tipo = MapearTipo(reader["Tipo"].ToString()),
                            Superficie = Convert.ToDouble(reader["Superficie"]),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Estado = MapearEstado(reader["Estado"].ToString()),
                            AgenteID = reader["AgenteID"] != DBNull.Value ? Convert.ToInt32(reader["AgenteID"]) : 0
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<Propiedad> GetAll()
        {
            var propiedades = new List<Propiedad>();
            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            using (var cmd = new SqlCommand("SP_ObtenerTodasPropiedades", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        propiedades.Add(new Propiedad
                        {
                            PropiedadID = Convert.ToInt32(reader["PropiedadID"]),
                            Direccion = reader["Direccion"].ToString(),
                            Tipo = MapearTipo(reader["Tipo"].ToString()),
                            Superficie = Convert.ToDouble(reader["Superficie"]),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Estado = MapearEstado(reader["Estado"].ToString()),
                            AgenteID = reader["AgenteID"] != DBNull.Value ? Convert.ToInt32(reader["AgenteID"]) : 0
                        });
                    }
                }
            }

            return propiedades;
        }


        private TipoPropiedad MapearTipo(string tipo)
        {
            switch (tipo)
            {
                case "Apartamento":
                    return TipoPropiedad.Apartamento;
                case "Casa":
                    return TipoPropiedad.Casa;
                case "Oficina":
                    return TipoPropiedad.Oficina;
                default:
                    throw new ArgumentOutOfRangeException("Tipo de propiedad desconocido: " + tipo);
            }
        }

        private EstadoPropiedad MapearEstado(string estado)
        {
            switch (estado)
            {
                case "Disponible":
                    return EstadoPropiedad.Disponible;
                case "En proceso de venta":
                    return EstadoPropiedad.EnProcesoVenta;
                case "Vendida":
                    return EstadoPropiedad.Vendida;
                default:
                    throw new ArgumentOutOfRangeException("Estado de propiedad desconocido: " + estado);
            }
        }

        public IEnumerable<Propiedad> GetByAgenteId(int agenteId)
        {
            var propiedades = new List<Propiedad>();
            using (var cmd = new SqlCommand("SELECT * FROM Propiedades WHERE AgenteID = @AgenteID", _connection, _transaction))
            {
                cmd.Parameters.AddWithValue("@AgenteID", agenteId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        propiedades.Add(new Propiedad
                        {
                            PropiedadID = Convert.ToInt32(reader["PropiedadID"]),
                            Direccion = reader["Direccion"].ToString(),
                            Tipo = MapearTipo(reader["Tipo"].ToString()),
                            Superficie = Convert.ToDouble(reader["Superficie"]),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Estado = MapearEstado(reader["Estado"].ToString()),
                            AgenteID = reader["AgenteID"] != DBNull.Value ? Convert.ToInt32(reader["AgenteID"]) : 0
                        });
                    }
                }
            }
            return propiedades;
        }

        public IEnumerable<Propiedad> GetDisponibles()
        {
            var propiedades = new List<Propiedad>();
            using (var cmd = new SqlCommand("SP_ObtenerPropiedadesDisponibles", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        propiedades.Add(new Propiedad
                        {
                            PropiedadID = Convert.ToInt32(reader["PropiedadID"]),
                            Direccion = reader["Direccion"].ToString(),
                            Tipo = MapearTipo(reader["Tipo"].ToString()),
                            Superficie = Convert.ToDouble(reader["Superficie"]),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Estado = MapearEstado(reader["Estado"].ToString()),
                            AgenteID = reader["AgenteID"] != DBNull.Value ? Convert.ToInt32(reader["AgenteID"]) : 0
                        });
                    }
                }
            }
            return propiedades;
        }
    }
}