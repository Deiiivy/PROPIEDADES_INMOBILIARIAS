using System.Data;
using System.Data.SqlClient;
using PROPIEDADES_INMOBILIARIAS.Models;

namespace PROPIEDADES_INMOBILIARIAS.Repositories
{
    public class AuthRepository
    {
        private readonly SqlConnection _connection;

        public AuthRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public Usuario Login(string email, string password)
        {
            using (var cmd = new SqlCommand("SP_ObtenerUsuario", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            UsuarioID = (int)reader["UsuarioID"],
                            Nombre = reader["Nombre"].ToString(),
                            Email = reader["Email"].ToString(),
                            Rol = reader["Rol"].ToString(),
                            AgenteID = reader["AgenteID"] as int?,
                            ClienteID = reader["ClienteID"] as int?
                        };
                    }
                }
            }
            return null;
        }
    }
}
