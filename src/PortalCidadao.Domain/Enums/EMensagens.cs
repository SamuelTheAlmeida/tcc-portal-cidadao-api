using System.ComponentModel;

namespace PortalCidadao.Domain.Enums
{
    public enum EMensagens
    {
        [Description("Operação realizada com sucesso")]
        RealizadaComSucesso = 1,

        [Description("Ocorreu um erro não identificado na aplicação. Tente novamente mais tarde ou entre em contato com o suporte técnico")]
        ErroInterno = 99,
    }
}
