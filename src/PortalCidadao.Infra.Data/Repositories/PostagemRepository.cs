using Dapper;
using PortalCidadao.Domain.Models;
using System.Collections.Generic;
using System.Data;
using PortalCidadao.Api.Domain.Models;
using PortalCidadao.Application.Repositories;
using System.Threading.Tasks;

namespace PortalCidadao.Infra.Data.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly IDbConnection _dbConnection;

        public PostagemRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Postagem>> ListarTodos()
        {
            var sql = @"
            SELECT P.*, C.* 
            FROM Postagem P 
            INNER JOIN Categoria C ON C.Id = P.CategoriaId";

            return await _dbConnection.QueryAsync<Postagem, Categoria, Postagem>(sql, (p, c) =>
            {
                p.Categoria = c;
                return p;
            });
        }

        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
            var sql = @"
            SELECT C.* 
            FROM Categoria C";

            return await _dbConnection.QueryAsync<Categoria>(sql);
        }

        public async Task Inserir(Postagem postagem)
        {
            var sql = @"INSERT INTO Postagem 
                        (CategoriaId, Subcategoria, Titulo, Descricao, ImagemUrl, Latitude, Longitude, Bairro, UsuarioId, DataCadastro, Resolvido)
                    VALUES(1, 1, 'Teste', 'Teste teste', 'teste', @Latitude, @Longitude, 'Teste', 1, NOW(), 0); ";

            await _dbConnection.ExecuteAsync(sql, new 
            {
                postagem.Latitude,
                postagem.Longitude 
            });
        }
    }
}
