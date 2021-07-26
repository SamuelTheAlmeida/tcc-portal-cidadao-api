using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Infra.Data.Repositories;

namespace PortalCidadao.CrossCutting
{
    public static class RegisterServicesExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Infra.Data
            var dbConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<IDbConnection>((sp) => new MySqlConnection(dbConnectionString));

            services.AddScoped<IPostagemRepository, PostagemRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            #endregion

            #region Application
            services.AddScoped<IPostagemService, PostagemService>();

            #endregion
        }
    }
}
