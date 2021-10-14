﻿using Dapper;
using PortalCidadao.Domain.Models;
using System.Collections.Generic;
using System.Data;
using PortalCidadao.Api.Domain.Models;
using PortalCidadao.Application.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace PortalCidadao.Infra.Data.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly IDbConnection _dbConnection;

        public ComentarioRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        
        public async Task Inserir(Comentario comentario)
        {
            var sql = @"INSERT INTO Comentario 
                        (PostagemId, UsuarioId, Descricao, DataCadastro)
                    VALUES(@PostagemId, @UsuarioId, @Descricao, @DataCadastro); ";

            await _dbConnection.QueryAsync(sql, comentario);

        }


         public async Task<IEnumerable<Comentario>> ListarTodos(int postagemId)
        {
            const string sql = @"
                    SELECT C.* 
                    FROM Comentario C 
                    WHERE C.PostagemId = @postagemId";

            return await _dbConnection.QueryAsync<Comentario>(sql, new {postagemId});

        }

         
    }

  
} 
   
