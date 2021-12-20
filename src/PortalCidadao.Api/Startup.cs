using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.HttpOverrides;
using PortalCidadao.Application.Model;
using PortalCidadao.CrossCutting;
using PortalCidadao.Api.Middlewares;
using PortalCidadao.Shared.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace PortalCidadao.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigurationHelper.CarregarConfiguracoes(Configuration);
            services.RegisterServices(Configuration);
            services.AddAutoMapper(typeof(PostagemModel));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PortalCidadao.Api", 
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Equipe de Desenvolvimento",
                        Email = "portalcidadaoapp@gmail.com",
                        Url = new Uri("https://portalcidadao.tk")
                    },
                    Description = "API da plataforma web e móvel do Portal Cidadão"
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "PortalCidadao.Api.xml");
                c.IncludeXmlComments(filePath);

            });
            services.AddHttpContextAccessor();

            const string key = "c3ecf6c5baf0b269698c385e4a647f3e";
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePathBase(new PathString("/api"));
            }

            app.UseCors();
            app.UseSwaggerAuthorized("ufpr", "jn$*Q8&3");
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PortalCidadao.Api v1");
                c.RoutePrefix = "";
            });

            app.UseRouting();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.ConfigureExceptionHandler(Configuration.GetValue<bool>("InternalServerErrorWithException"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
