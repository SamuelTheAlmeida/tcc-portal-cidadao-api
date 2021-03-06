using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Application.Validators;
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

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPostagemRepository, PostagemRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IArquivoRepository, ArquivoRepository>();
            services.AddScoped<ICurtidaRepository, CurtidaRepository>();
            services.AddScoped<IComentarioRepository, ComentarioRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            #endregion

            #region Application
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPostagemService, PostagemService>();
            services.AddScoped<IArquivoService, ArquivoService>();
            services.AddScoped<ICurtidaService, CurtidaService>();
            services.AddScoped<IComentarioService, ComentarioService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IPontuacaoService, PontuacaoService>();
            #endregion

            #region Validators
            services.AddScoped<LoginModelValidator, LoginModelValidator>();
            services.AddScoped<UsuarioCadastroModelValidator, UsuarioCadastroModelValidator>();
            #endregion Validators
        }
    }
}
