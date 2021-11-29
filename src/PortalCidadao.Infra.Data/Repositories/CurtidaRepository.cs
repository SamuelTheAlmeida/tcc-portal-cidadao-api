using System.Collections.Generic;
using Dapper;
using PortalCidadao.Domain.Models;
using System.Data;
using PortalCidadao.Application.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace PortalCidadao.Infra.Data.Repositories
{
    public class CurtidaRepository : ICurtidaRepository
    {
        private readonly IDbConnection _dbConnection;

        public CurtidaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task Inserir(Curtida curtida)
        {
            const string sql = @"INSERT INTO Curtida 
                        (PostagemId, UsuarioId, Acao, Pontos)
                    VALUES(@PostagemId, @UsuarioId, @Acao, @Pontos); ";

            await _dbConnection.QueryAsync(sql, curtida);
        }

        public async Task<Curtida> ObterCurtida(int postagemId, int usuarioId)
        {
            const string sql = @"
                    SELECT C.* 
                    FROM Curtida C                     
                    WHERE C.UsuarioId = @usuarioId
                    AND C.PostagemId = @postagemId";

            var resultado = await _dbConnection.QueryAsync<Curtida>(sql, new{ postagemId, usuarioId});            

            return resultado.FirstOrDefault();
        }

        public async Task<IEnumerable<Curtida>> ObterCurtidasPorUsuario(int usuarioId)
        {
            const string sql = @"
                    SELECT C.* 
                    FROM Curtida C
                    INNER JOIN Postagem P
                    ON P.Id = C.PostagemId
                    WHERE P.UsuarioId = @usuarioId";

            var resultado = await _dbConnection.QueryAsync<Curtida>(sql, new { usuarioId });

            return resultado;
        }

        public async Task<Curtida> RemoverCurtida(int curtidaId)
        {
            const string sql = @"
                    DELETE C 
                    FROM Curtida C                     
                    WHERE C.Id = @curtidaId";

                var resultado = await _dbConnection.QueryAsync(sql, new {curtidaId});            

            return resultado.FirstOrDefault();           
        }

        public async Task<Curtida> AtualizarCurtida(int curtidaId, bool Acao)
        {
            const string sql = @"
                    UPDATE Curtida C                    
                    SET C.Acao = @Acao
                    WHERE C.Id = @curtidaId";                  
                    
                 var resultado = await _dbConnection.QueryAsync(sql, new { curtidaId, Acao });            

            return resultado.FirstOrDefault(); 
        }
    }

  
} 
   
