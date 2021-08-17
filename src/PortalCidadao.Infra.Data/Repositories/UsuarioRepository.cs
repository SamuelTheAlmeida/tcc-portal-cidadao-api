using PortalCidadao.Application.Repositories;
using PortalCidadao.Domain.Models;
using PortalCidadao.Shared.Helpers;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PortalCidadao.Infra.Data.Repositories
{
    class UsuarioRepository : IUsuarioRepository
    {
        private readonly string connectionString;
        public UsuarioRepository()
        {
            connectionString = ConfigurationHelper.ConnectionString;
        }

        public async Task<Usuario> AutenticarAsync(string email, string senha)
        {
            var query =
            " SELECT                        " +
            "   Id,                         " +
            "   Email,                      " +
            "   Perfil                      " +
            " FROM                          " +
            "   Usuario                     " +
            " WHERE                         " +
            "   1=1                         " +
            "   AND email = @email          " +
            "   AND senha = @senha          ";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);
                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return new Usuario()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        //Perfil = (EPerfis)reader.GetInt32(reader.GetOrdinal("Perfil"))
                    };
                }
            }
            return default;
        }
    }
}
