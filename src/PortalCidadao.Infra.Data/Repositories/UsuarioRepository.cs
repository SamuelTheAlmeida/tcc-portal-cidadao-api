using Dapper;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Domain.Models;
using System;
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
                        AND (LOWER(email) = LOWER(@login) OR cpf = @login)
                        AND senha = @senha";

            return await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(sql, new { login, senha });

        }

        public async Task<Usuario> InserirAsync(Usuario usuario)
        {
            var sql = @"INSERT INTO Usuario
                            (Nome, Cpf, Email, Senha, Perfil, EmailConfirmado, DataCadastro)
                        VALUES
                            (@Nome, @Cpf, @Email, @Senha, @Perfil, 0, NOW())";

            await _dbConnection.QueryAsync(sql, usuario);
            usuario.Senha = string.Empty;
            return usuario;
        }

        public async Task<Usuario> ObterUsuarioAsync(string cpf = "", string email = "")
        {
            var sql = @"SELECT U.*
                        FROM Usuario U
                        WHERE 1=1 
                        AND (U.Cpf = @cpf OR LOWER(U.Email) = LOWER(@email))";

            return await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(sql, new { cpf, email });
        }

        public async Task<Usuario> ObterUsuarioPorIdAsync(int id)
        {
            var sql = @"SELECT U.*
                        FROM Usuario U
                        WHERE 1=1 
                        AND U.Id = @id";

            return await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(sql, new { id });
        }

        public async Task<Usuario> VerificarEmailAsync(string email, int usuarioId)
        {
            var sql = @"SELECT U.*
                        FROM Usuario U
                        WHERE LOWER(U.Email) = LOWER(@email) AND U.Id != @usuarioId";

            return await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(sql, new { email, usuarioId });
        }

        public async Task<Usuario> AtualizarAsync(Usuario usuario, int id)
        {
            usuario.Nome = string.IsNullOrEmpty(usuario.Nome) ? default : usuario.Nome;
            usuario.Email = string.IsNullOrEmpty(usuario.Email) ? default : usuario.Email;
            usuario.Senha = string.IsNullOrEmpty(usuario.Senha) ? default : usuario.Senha;
            usuario.Id = id;

            const string sql = @"UPDATE Usuario 
                                SET 
                                Email = CASE WHEN ISNULL(@Email) THEN Email ELSE @Email END,
                                Nome = CASE WHEN ISNULL(@Nome) THEN Senha ELSE @Nome END
                                WHERE Id = @Id";

            await _dbConnection.ExecuteAsync(sql, usuario);
            return usuario;
        }

        public async Task AtualizarTokenRedefinicaoSenha(int usuarioId, Guid? token)
        {
            const string sql = @"UPDATE Usuario 
                                SET 
                                TokenRedefinicaoSenha = @token
                                WHERE Id = @usuarioId";

            await _dbConnection.ExecuteAsync(sql, new { usuarioId, token });
        }

        public async Task<Usuario> BuscarPorTokenRedefinicaoSenha(Guid? token)
        {
            const string sql = @"SELECT U.* 
                                FROM Usuario U
                                WHERE TokenRedefinicaoSenha = @token";

            return await _dbConnection.QueryFirstOrDefaultAsync<Usuario>(sql, new { token });
        }
    }
}