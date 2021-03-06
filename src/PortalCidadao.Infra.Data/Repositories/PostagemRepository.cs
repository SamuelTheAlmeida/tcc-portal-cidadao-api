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
    public class PostagemRepository : IPostagemRepository
    {
        private readonly IDbConnection _dbConnection;

        public PostagemRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Postagem>> ListarTodos(string bairro, int categoriaId, int subcategoriaId, string confiabilidade)
        {
            var bairroParam = string.IsNullOrEmpty(bairro) ? default : bairro;
            var categoriaIdParam = categoriaId > 0 ? (int?)categoriaId : null;
            var subCategoriaIdParam = subcategoriaId > 0 ? (int?)subcategoriaId : null;
            var confiabilidadeParam = string.IsNullOrEmpty(confiabilidade) ? default : confiabilidade;
           
            const string sql = @"
                    SELECT P.*, C.* 
                    FROM Postagem P 
                    INNER JOIN Categoria C
                    ON C.Id = P.CategoriaId
                    WHERE P.Bairro = IFNULL(@bairroParam, P.Bairro) AND 
                    P.Confiabilidade = IFNULL(@confiabilildadeParam, P.Confiabilidade) AND
                    P.Resolvido = 0 AND
                    P.CategoriaId = IFNULL(@categoriaIdParam, P.CategoriaId) AND
                    P.Subcategoria = IFNULL(@subCategoriaIdParam, P.Subcategoria)                    
                    AND P.Excluida = 0";

            return await _dbConnection.QueryAsync<Postagem, Categoria, Postagem>(sql, (p, c) =>
            {
                p.Categoria = c;
                return p;
            }, new { bairroParam, categoriaIdParam, subCategoriaIdParam, confiabilidadeParam });
        }

         public async Task<IEnumerable<Postagem>> PostagensAbertasPorMes(string mes)
        {            
            var mesParam = string.IsNullOrEmpty(mes) ? default : mes;


            const string sql = @"
                    SELECT P.* 
                    FROM Postagem P                     
                    WHERE P.Resolvido = 0 AND                    
                    MONTH(P.DataCadastro) = IFNULL(@mesParam, MONTH(P.DataCadastro))
                    AND P.Excluida = 0";

           return await _dbConnection.QueryAsync<Postagem>(sql, new {mesParam});
        }

        public async Task<IEnumerable<Postagem>> ListarPorCategoria(string categoria)
        {
            const string sql = @"
                    SELECT P.*, C.* 
                    FROM Postagem P 
                    INNER JOIN Categoria C ON C.Id = P.CategoriaId
                    WHERE C.Nome = @categoria
                    AND P.Excluida = 0";

            return await _dbConnection.QueryAsync<Postagem, Categoria, Postagem>(sql, (p, c) =>
            {
                p.Categoria = c;
                return p;
            }, new { categoria });
        }

        public async Task<int> TotalPorUsuario(int usuarioId)
        {
            const string sql = @"
                    SELECT COUNT(*) 
                    FROM Postagem P 
                    WHERE P.UsuarioId = @usuarioId
                    AND P.Excluida = 0";

            return await _dbConnection.QueryFirstAsync<int>(sql, new { usuarioId });
        }

        public async Task<Postagem> resolverPostagem(int id, bool resolvido)
        {
            const string sql = @"
                    UPDATE Postagem P                    
                    SET P.Resolvido = @resolvido,
                    P.DataResolucao = NOW()
                    WHERE P.Id = @id";                  
                    
                 var resultado = await _dbConnection.QueryAsync(sql, new { id, resolvido });            

            return resultado.FirstOrDefault(); 
        }
        public async Task<Postagem> ObterPorId(int id)
        {
            const string sql = @"
                    SELECT P.*, C.* 
                    FROM Postagem P 
                    INNER JOIN Categoria C ON C.Id = P.CategoriaId
                    WHERE P.Id = @id";

            var resultado = await _dbConnection.QueryAsync<Postagem, Categoria, Postagem>(sql, (p, c) =>
            {
                p.Categoria = c;
                return p;
            }, new { id });

            return resultado.FirstOrDefault();
        }
        public async Task<Postagem> removerPostagem(int id, bool excluir)
        {
            
            const string sql = @"
                    UPDATE Postagem P
                    SET P.Excluida = @excluir                   
                    WHERE P.Id = @id";

                var resultado = await _dbConnection.QueryAsync(sql, new {id, excluir});            

            return resultado.FirstOrDefault();           
        }

        public async Task<Postagem> ObterDetalhado(int id)
        {
            const string sqlCurtidas = @"(SELECT COUNT(*)
                    FROM Curtida C
                    WHERE C.PostagemId = @id AND C.Acao = true)";

            const string sqlDescurtidas = @"(SELECT COUNT(*)
                    FROM Curtida C
                    WHERE C.PostagemId = @id AND C.Acao = false)";

            var sql = $@"SELECT P.*, C.*, U.*, 
                    {sqlCurtidas} 
                    AS Curtidas,
                    {sqlDescurtidas} 
                    AS Descurtidas
                    FROM Postagem P 
                    INNER JOIN Categoria C ON C.Id = P.CategoriaId
                    INNER JOIN Usuario U ON U.Id = P.UsuarioId
                    WHERE P.Id = @id;";

            var resultado = await _dbConnection.QueryAsync<Postagem, Categoria, Usuario, long, long, Postagem>(sql, (p, c, u, curtidas, descurtidas) =>
            {
                p.Categoria = c;
                p.Usuario = u;
                p.Curtidas = curtidas;
                p.Descurtidas = descurtidas;
                return p;
            }, new { id }, splitOn: "Id,Id,Id,Curtidas,Descurtidas");

            return resultado.FirstOrDefault();
        }

        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
            const string sql = @"
            SELECT C.* 
            FROM Categoria C";

            return await _dbConnection.QueryAsync<Categoria>(sql);
        }

        public async Task<IEnumerable<string>> ListarBairros()
        {
            const string sql = @"
            SELECT DISTINCT P.Bairro 
            FROM Postagem P 
            ORDER BY 1";

            return await _dbConnection.QueryAsync<string>(sql);
        }
         public async Task<IEnumerable<string>> ListarConfiabilidades()
        {
            const string sql = @"
            SELECT DISTINCT P.Confiabilidade
            FROM Postagem P 
            ORDER BY 1";

            return await _dbConnection.QueryAsync<string>(sql);
        }

        public async Task Inserir(Postagem postagem)
        {
            const string sql = @"INSERT INTO Postagem 
                        (CategoriaId, Subcategoria, Titulo, Descricao, ImagemUrl, Latitude, Longitude, Bairro, UsuarioId, DataCadastro, Resolvido, Excluida, Confiabilidade)
                    VALUES(@CategoriaId, @Subcategoria, @Titulo, @Descricao, @ImagemUrl, @Latitude, @Longitude, @Bairro, @UsuarioId, NOW(), @Resolvido, 0, @Confiabilidade); ";

            await _dbConnection.QueryAsync(sql, postagem);
        }
    }
}
