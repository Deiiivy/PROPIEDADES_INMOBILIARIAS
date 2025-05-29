using System.Data;
using System.Data.SqlClient;
using PROPIEDADES_INMOBILIARIAS.Models;
using System.Collections.Generic;
using System;

namespace PROPIEDADES_INMOBILIARIAS.Repositories
{
    public class VisitaRepository : IRepository<Visita>
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public VisitaRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public void Add(Visita visita)
        {
            using (var cmd = new SqlCommand("SP_InsertarVisita", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PropiedadID", visita.PropiedadID);
                cmd.Parameters.AddWithValue("@ClienteID", visita.ClienteID);
                cmd.Parameters.AddWithValue("@AgenteID", visita.AgenteID);
                cmd.Parameters.AddWithValue("@Fecha", visita.Fecha);
                cmd.Parameters.AddWithValue("@Hora", visita.Hora);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Visita visita)
        {
            using (var cmd = new SqlCommand("SP_ActualizarVisita", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VisitaID", visita.VisitaID);
                cmd.Parameters.AddWithValue("@Fecha", visita.Fecha);
                cmd.Parameters.AddWithValue("@Hora", visita.Hora);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cmd = new SqlCommand("SP_EliminarVisita", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VisitaID", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Visita GetById(int id)
        {
            using (var cmd = new SqlCommand("SP_ObtenerVisitaPorID", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VisitaID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Visita
                        {
                            VisitaID = (int)reader["VisitaID"],
                            PropiedadID = (int)reader["PropiedadID"],
                            ClienteID = (int)reader["ClienteID"],
                            AgenteID = (int)reader["AgenteID"],
                            Fecha = (DateTime)reader["Fecha"],
                            Hora = TimeSpan.Parse(reader["Hora"].ToString())
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<Visita> GetAll()
        {
            var visitas = new List<Visita>();
            using (var cmd = new SqlCommand("SP_ObtenerTodasVisitas", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        visitas.Add(new Visita
                        {
                            VisitaID = (int)reader["VisitaID"],
                            PropiedadID = (int)reader["PropiedadID"],
                            ClienteID = (int)reader["ClienteID"],
                            AgenteID = (int)reader["AgenteID"],
                            Fecha = (DateTime)reader["Fecha"],
                            Hora = TimeSpan.Parse(reader["Hora"].ToString())
                        });
                    }
                }
            }
            return visitas;
        }

        public IEnumerable<Visita> GetVisitasPorCliente(int clienteId)
        {
            var visitas = new List<Visita>();
            using (var cmd = new SqlCommand("SP_ObtenerVisitasPorCliente", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClienteID", clienteId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        visitas.Add(new Visita
                        {
                            VisitaID = (int)reader["VisitaID"],
                            PropiedadID = (int)reader["PropiedadID"],
                            ClienteID = (int)reader["ClienteID"],
                            AgenteID = (int)reader["AgenteID"],
                            Fecha = (DateTime)reader["Fecha"],
                            Hora = TimeSpan.Parse(reader["Hora"].ToString())
                        });
                    }
                }
            }
            return visitas;
        }

    }
}
