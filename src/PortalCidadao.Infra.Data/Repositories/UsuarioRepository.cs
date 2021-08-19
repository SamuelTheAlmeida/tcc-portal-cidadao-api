using Dapper;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Domain.Models;
using System.Data;
using System.Threading.Tasks;

namespace PortalCidadao.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _dbConnection;
        public UsuarioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Usuario> AutenticarAsync(string login, string senha)
        {
            var sql = @"SELECT U.*
                        FROM Usuario U
                        WHERE 1=1 
                        AND (email = @login OR cpf = @login)
                        AND senha = @senha";

            return await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(sql, new { login, senha });

        }

        public async Task<Usuario> InserirAsync(Usuario usuario)
        {
            var sql = @"INSERT INTO Usuario
                            (Nome, Cpf, Email, Senha, Perfil, EmailConfirmado, DataCadastro)
                        VALUES
                            (@Nome, @Cpf, @Email, @Senha, @Perfil, 0, @DataCadastro)";

            await _dbConnection.QueryAsync(sql, usuario);
            usuario.Senha = string.Empty;
            return usuario;
        }
    }
}