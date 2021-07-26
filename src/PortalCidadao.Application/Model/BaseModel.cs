using System.ComponentModel.DataAnnotations;
using PortalCidadao.Domain.Enums;
using PortalCidadao.Shared.Extensions;

namespace PortalCidadao.Application.Model
{
    public class BaseModel<T>
    {
        public T Dados { get; set; }

        public int? Pagina { get; set; }

        public int? TamanhoPagina { get; set; }

        public int? TotalRegistros { get; set; }

        public int? TotalPaginas { get; set; }

        public EnumModel Mensagem { get; set; }

        public ValidationResult[] ResultadoValidacao { get; set; }

        public bool Sucesso { get; set; }

        public BaseModel()
        {
        }

        public BaseModel(bool sucesso, EMensagens mensagem)
        {
            Sucesso = sucesso;
            Mensagem = new EnumModel
            {
                Codigo = mensagem.GetEnumValue(),
                Nome = mensagem.GetEnumName(),
                Descricao = mensagem.GetEnumDescription()
            };
        }

        public BaseModel(bool sucesso, EMensagens mensagem, T dados) : this(sucesso, mensagem) => Dados = dados;

        public BaseModel(bool sucesso, EMensagens mensagem, T dados, ValidationResult[] resultadoValidacao) : this(sucesso, mensagem, dados) => ResultadoValidacao = resultadoValidacao;

    }

    public class BaseModel : BaseModel<dynamic>
    {
        public BaseModel()
        {

        }

        public BaseModel(bool sucesso, EMensagens mensagem) : base(sucesso, mensagem)
        {

        }

        public BaseModel(bool sucesso, EMensagens mensagem, dynamic dados) : base(sucesso, mensagem) => Dados = dados;

        public BaseModel(bool sucesso, EMensagens mensagem, dynamic dados, ValidationResult[] resultadoValidacao) : base(sucesso, mensagem)
        {
            Dados = dados;
            ResultadoValidacao = resultadoValidacao;
        }

        public BaseModel(dynamic dados) : base(true, EMensagens.RealizadaComSucesso) => Dados = dados;
    }
}
