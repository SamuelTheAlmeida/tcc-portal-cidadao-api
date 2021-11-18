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
