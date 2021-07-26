using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PortalCidadao.Application.Model;
using PortalCidadao.Domain.Enums;

namespace PortalCidadao.Api.Middlewares
{
    public static class ExceptionHandlingMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, bool internalServerErrorWithException)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    var exception = contextFeature.Error.InnerException ?? contextFeature.Error;

                    var resultadoOperacao = new BaseModel<Exception>(sucesso: false, mensagem: EMensagens.ErroInterno, dados: (internalServerErrorWithException ? exception : null));

                    string json = JsonConvert.SerializeObject(resultadoOperacao,
                        new JsonSerializerSettings
                        {
                            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                            Formatting = Formatting.Indented,
                            NullValueHandling = NullValueHandling.Ignore
                        });

                    await context.Response.WriteAsync(json);
                });
            });
        }
    }
}
