using System.Data;
using System.Data.SqlClient;
using PROPIEDADES_INMOBILIARIAS.Models;
using System.Collections.Generic;
using System;

namespace PROPIEDADES_INMOBILIARIAS.Repositories
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public ClienteRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public void Add(Cliente cliente)
        {
            try
            {
                using (var cmd = new SqlCommand("SP_InsertarCliente", _connection, _transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@Interes", cliente.Interes);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cliente: " + ex.Message, ex);
            }
        }

        public void Update(Cliente cliente)
        {
            try
            {
                using (var cmd = new SqlCommand("SP_ActualizarCliente", _connection, _transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@Interes", cliente.Interes);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cliente: " + ex.Message, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var cmd = new SqlCommand("SP_EliminarCliente", _connection, _transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteID", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) when (ex.Message.Contains("REFERENCE constraint"))
            {
                throw new Exception("No se puede eliminar el cliente porque está relacionado con otros registros (por ejemplo, transacciones o visitas).", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente: " + ex.Message, ex);
            }
        }

        public Cliente GetById(int id)
        {
            try
            {
                using (var cmd = new SqlCommand("SP_ObtenerClientePorID", _connection, _transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteID", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                ClienteID = (int)reader["ClienteID"],
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Email = reader["Email"].ToString(),
                                Interes = reader["Interes"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener cliente por ID: " + ex.Message, ex);
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            var clientes = new List<Cliente>();
            try
            {
                using (var cmd = new SqlCommand("SP_ObtenerTodosClientes", _connection, _transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                ClienteID = (int)reader["ClienteID"],
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Email = reader["Email"].ToString(),
                                Interes = reader["Interes"].ToString()
                            });
                        }
                    }
                }
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de clientes: " + ex.Message, ex);
            }
        }
    }
}
