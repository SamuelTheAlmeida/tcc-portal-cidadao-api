using Dapper;
using PortalCidadao.Domain.Models;
using System.Collections.Generic;
using System.Data;
using PortalCidadao.Api.Domain.Models;
using PortalCidadao.Application.Repositories;

namespace PortalCidadao.Infra.Data.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly IDbConnection _dbConnection;

        public PostagemRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Postagem> ListarTodos()
        {
            const string sql = @"
            SELECT P.*, C.* 
            FROM Postagem P 
            INNER JOIN Categoria C ON C.Id = P.CategoriaId";

            return _dbConnection.Query<Postagem, Categoria, Postagem>(sql, (p, c) =>
            {
                p.Categoria = c;
                return p;
            });
        }
    }
}
