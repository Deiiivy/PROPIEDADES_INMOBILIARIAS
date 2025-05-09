using System.Data;
using System.Data.SqlClient;
using PROPIEDADES_INMOBILIARIAS.Models;
using PROPIEDADES_INMOBILIARIAS.Strategies;
using System.Collections.Generic;
using System;

namespace PROPIEDADES_INMOBILIARIAS.Repositories
{
    public class AgenteRepository : IRepository<Agente>
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private readonly IZonaStrategy _zonaStrategy;

        public AgenteRepository(SqlConnection connection, SqlTransaction transaction,
                              IZonaStrategy zonaStrategy = null)
        {
            _connection = connection;
            _transaction = transaction;
            _zonaStrategy = zonaStrategy ?? new ZonaValidationStrategy();
        }

        public void Add(Agente agente)
        {
            using (var cmd = new SqlCommand("SP_InsertarAgente", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", agente.Nombre);
                cmd.Parameters.AddWithValue("@ZonaEspecializacion", agente.ZonaEspecializacion);
                cmd.Parameters.AddWithValue("@Telefono", agente.Telefono);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Agente agente)
        {
            using (var cmd = new SqlCommand("SP_ActualizarAgente", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AgenteID", agente.AgenteID);
                cmd.Parameters.AddWithValue("@Nombre", agente.Nombre);
                cmd.Parameters.AddWithValue("@ZonaEspecializacion", agente.ZonaEspecializacion);
                cmd.Parameters.AddWithValue("@Telefono", agente.Telefono);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cmd = new SqlCommand("SP_EliminarAgente", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AgenteID", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Agente GetById(int id)
        {
            using (var cmd = new SqlCommand("SP_ObtenerAgentePorID", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AgenteID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Agente
                        {
                            AgenteID = (int)reader["AgenteID"],
                            Nombre = reader["Nombre"].ToString(),
                            ZonaEspecializacion = reader["ZonaEspecializacion"].ToString(),
                            Telefono = reader["Telefono"].ToString()
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<Agente> GetAll()
        {
            var agentes = new List<Agente>();
            using (var cmd = new SqlCommand("SP_ObtenerTodosAgentes", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        agentes.Add(new Agente
                        {
                            AgenteID = (int)reader["AgenteID"],
                            Nombre = reader["Nombre"].ToString(),
                            ZonaEspecializacion = reader["ZonaEspecializacion"].ToString(),
                            Telefono = reader["Telefono"].ToString()
                        });
                    }
                }
            }
            return agentes;
        }

        // Método mejorado con validación de zona
        public void AsignarPropiedad(int agenteId, Propiedad propiedad)
        {
            var agente = GetById(agenteId);

            if (!_zonaStrategy.ValidarZonaAgente(propiedad.Zona, agente.ZonaEspecializacion))
                throw new InvalidOperationException("El agente no está autorizado para gestionar propiedades en esta zona");

            propiedad.AgenteID = agenteId;
            // Aquí deberías usar el repositorio de propiedades para actualizar
        }
    }
}