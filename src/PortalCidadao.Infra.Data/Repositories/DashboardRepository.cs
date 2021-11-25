using Dapper;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Domain.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PortalCidadao.Infra.Data.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IDbConnection _dbConnection;

        public DashboardRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<DashboardCategoria>> ObterDashboardCategoria()
        {
            const string sql = @"
                            SELECT 
                            C.Nome AS NomeCategoria, COUNT(P.Id) AS QtdPostagens
                            FROM 
                            Postagem P
                            INNER JOIN Categoria C ON P.CategoriaId = C.Id
                            WHERE P.Excluida = 0
                            GROUP BY C.Id;";

            return await _dbConnection.QueryAsync<DashboardCategoria>(sql);
        }
         public async Task<DashboardAtrasados> ObterDashboardAtrasados(string mes)
        {
            var mesParam = string.IsNullOrEmpty(mes) ? default : mes;
            const string sql = @"
                    SELECT COUNT(P.Id) AS QtdPostagens,
                    CASE @mesParam
                    WHEN '1' THEN 'Janeiro'
                    WHEN '2' THEN 'Fevereiro'
                    WHEN '3' THEN 'Março'
                    WHEN '4' THEN 'Abril'
                    WHEN '5' THEN 'Maio'
                    WHEN '6' THEN 'Junho'
                    WHEN '7' THEN 'Julho'
                    WHEN '8' THEN 'Agosto'
                    WHEN '9' THEN 'Setembro'
                    WHEN '10' THEN 'Outubro'
                    WHEN '11' THEN 'Novembro'
                    WHEN '12' THEN 'Dezembro'
                    END AS Mes
                    FROM Postagem P                     
                    WHERE           
                    MONTH(P.DataCadastro) = IFNULL(@mesParam, MONTH(P.DataCadastro))
                    AND (DATEDIFF(P.DataResolucao, P.DataCadastro) <= -15 OR DATEDIFF(P.DataCadastro, NOW()) <= -15)                   
                   ";

            return await _dbConnection.QueryFirstAsync<DashboardAtrasados>(sql, new {mesParam});
        }

         public async Task<int> ObterTotalAtrasados()
         {
             const string sql = @"
                    SELECT COUNT(P.Id) AS QtdPostagens
                    FROM Postagem P                     
                    WHERE           
                    DATEDIFF(P.DataResolucao, P.DataCadastro) <= -15 OR DATEDIFF(P.DataCadastro, NOW()) <= -15              
                   ";

             return await _dbConnection.QueryFirstAsync<int>(sql);
         }

        public async Task<IEnumerable<DashboardBairros>> ObterDashboardBairros()
        {
            const string sql = @"
                        SELECT 
                        P.Bairro AS Bairro, COUNT(P.Id) AS QtdPostagens
                        FROM 
                        Postagem P
                        WHERE P.Excluida = 0
                        GROUP BY P.Bairro;";

            return await _dbConnection.QueryAsync<DashboardBairros>(sql);
        }

        public async Task<int> TotalPostagens()
        {
            const string sql = @"
                            SELECT 
                            COUNT(*)
                            FROM 
                            Postagem P
                            WHERE P.Excluida = 0";

            return await _dbConnection.QueryFirstAsync<int>(sql);
        }
        
    }
}
