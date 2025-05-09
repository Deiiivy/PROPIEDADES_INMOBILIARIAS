using System.Data;
using System.Data.SqlClient;
using PROPIEDADES_INMOBILIARIAS.Models;
using System.Collections.Generic;
using System;

namespace PROPIEDADES_INMOBILIARIAS.Repositories
{
    public class TransaccionRepository : IRepository<Transaccion>
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public TransaccionRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public void Add(Transaccion transaccion)
        {
            using (var cmd = new SqlCommand("SP_InsertarTransaccion", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PropiedadID", transaccion.PropiedadID);
                cmd.Parameters.AddWithValue("@ClienteID", transaccion.ClienteID);
                cmd.Parameters.AddWithValue("@Monto", transaccion.Monto);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Transaccion transaccion)
        {
            using (var cmd = new SqlCommand("SP_ActualizarTransaccion", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransaccionID", transaccion.TransaccionID);
                cmd.Parameters.AddWithValue("@Monto", transaccion.Monto);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var cmd = new SqlCommand("SP_EliminarTransaccion", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransaccionID", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Transaccion GetById(int id)
        {
            using (var cmd = new SqlCommand("SP_ObtenerTransaccionPorID", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransaccionID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Transaccion
                        {
                            TransaccionID = (int)reader["TransaccionID"],
                            PropiedadID = (int)reader["PropiedadID"],
                            ClienteID = (int)reader["ClienteID"],
                            FechaVenta = (DateTime)reader["FechaVenta"],
                            Monto = (decimal)reader["Monto"]
                        };
                    }
                    return null;
                }
            }
        }

        public IEnumerable<Transaccion> GetAll()
        {
            var transacciones = new List<Transaccion>();
            using (var cmd = new SqlCommand("SP_ObtenerTodasTransacciones", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transacciones.Add(new Transaccion
                        {
                            TransaccionID = (int)reader["TransaccionID"],
                            PropiedadID = (int)reader["PropiedadID"],
                            ClienteID = (int)reader["ClienteID"],
                            FechaVenta = (DateTime)reader["FechaVenta"],
                            Monto = (decimal)reader["Monto"]
                        });
                    }
                }
            }
            return transacciones;
        }
    }
}

