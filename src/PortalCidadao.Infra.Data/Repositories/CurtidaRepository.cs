using Dapper;
using PortalCidadao.Domain.Models;
using System.Collections.Generic;
using System.Data;
using PortalCidadao.Api.Domain.Models;
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
            var sql = @"INSERT INTO Curtida 
                        (PostagemId, UsuarioId, Acao, Pontos)
                    VALUES(@PostagemId, @UsuarioId, @Acao, @Pontos); ";

            await _dbConnection.QueryAsync(sql, curtida);

        }


        public async Task<Curtida> obterCurtida(int postagemId, int usuarioId)
        {
            const string sql = @"
                    SELECT C.* 
                    FROM Curtida C                     
                    WHERE C.UsuarioId = @usuarioId
                    AND C.PostagemId = @postagemId";

            var resultado = await _dbConnection.QueryAsync<Curtida>(sql, new{ postagemId, usuarioId});            

            return resultado.FirstOrDefault();
        }

         public async Task<Curtida> removerCurtida(int curtidaId)
        {
            const string sql = @"
                    DELETE C 
                    FROM Curtida C                     
                    WHERE C.Id = @curtidaId";

                var resultado = await _dbConnection.QueryAsync(sql, new {curtidaId});            

            return resultado.FirstOrDefault();           

                            

        }
       
        
         public async Task<Curtida> atualizarCurtida(int curtidaId, bool Acao)
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
   
