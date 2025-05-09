using System.Data;
using System.Data.SqlClient;
using PROPIEDADES_INMOBILIARIAS.Models;
using System.Collections.Generic;

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

        public void Update(Cliente cliente)
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

        public void Delete(int id)
        {
            using (var cmd = new SqlCommand("SP_EliminarCliente", _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClienteID", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Cliente GetById(int id)
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

        public IEnumerable<Cliente> GetAll()
        {
            var clientes = new List<Cliente>();
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
    }
}
