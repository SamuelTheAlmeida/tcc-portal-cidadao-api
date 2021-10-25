using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PortalCidadao.Application.Repositories;

namespace PortalCidadao.Infra.Data.Repositories
{
    public class ArquivoRepository : IArquivoRepository
    {
        private const string Diretorio = "uploads-portal-cidadao";

        public async Task<string> Salvar(IFormFile file)
        {
            var dataAtual = DateTime.Now;

            // output: 04102021_14143873_foto.jpg
            var nomeArquivo =
                $"{ObterData(dataAtual)}_{ObterTempo(dataAtual)}_{file.FileName}";
            var pasta = Path.Combine(Path.GetTempPath(), Diretorio);
            var caminho = Path.Combine(pasta, nomeArquivo);
            await using Stream stream = new FileStream(caminho, FileMode.Create);
            await file.CopyToAsync(stream);
            return nomeArquivo;
        }

        public async Task<byte[]> Obter(string nomeArquivo)
        {
            var pasta = Path.Combine(Path.GetTempPath(), Diretorio);
            return await File.ReadAllBytesAsync(Path.Combine(pasta, nomeArquivo));
        }

        public static string ObterData(DateTime dataAtual) =>
            $"{FormatarData(dataAtual.Day)}{FormatarData(dataAtual.Month)}{dataAtual.Year}";

        public static string ObterTempo(DateTime dataAtual) =>
            $"{FormatarData(dataAtual.Hour)}{FormatarData(dataAtual.Minute)}{FormatarData(dataAtual.Second)}{FormatarData(dataAtual.Millisecond)}";

        private static string FormatarData(int valor) => valor.ToString().PadLeft(2, '0');
    }
}
