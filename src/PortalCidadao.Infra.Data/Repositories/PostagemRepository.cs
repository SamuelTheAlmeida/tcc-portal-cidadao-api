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

        public async Task<IEnumerable<Postagem>> ListarTodos(string bairro)
        {
            var sql = @"
                    SELECT P.*, C.* 
                    FROM Postagem P 
                    INNER JOIN Categoria C ON C.Id = P.CategoriaId
                    WHERE P.Bairro = IFNULL(@bairro, P.Bairro)";

            return await _dbConnection.QueryAsync<Postagem, Categoria, Postagem>(sql, (p, c) =>
            {
                p.Categoria = c;
                return p;
            }, new { bairro });
        }

        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
            var sql = @"
            SELECT C.* 
            FROM Categoria C";

            return await _dbConnection.QueryAsync<Categoria>(sql);
        }

        public async Task<IEnumerable<string>> ListarBairros()
        {
            var sql = @"
            SELECT DISTINCT P.Bairro 
            FROM Postagem P 
            ORDER BY 1";

            return await _dbConnection.QueryAsync<string>(sql);
        }

        public async Task Inserir(Postagem postagem)
        {
            var sql = @"INSERT INTO Postagem 
                        (CategoriaId, Subcategoria, Titulo, Descricao, ImagemUrl, Latitude, Longitude, Bairro, UsuarioId, DataCadastro, Resolvido)
                    VALUES(@CategoriaId, @Subcategoria, @Titulo, @Descricao, '', @Latitude, @Longitude, @Bairro, @UsuarioId, NOW(), @Resolvido); ";

            await _dbConnection.QueryAsync(sql, postagem);

        }
    }
}
