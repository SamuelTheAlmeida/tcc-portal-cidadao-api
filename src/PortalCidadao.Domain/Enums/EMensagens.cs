using System.ComponentModel;

namespace PortalCidadao.Domain.Enums
{
    public enum EMensagens
    {
        [Description("Operação realizada com sucesso")]
        RealizadaComSucesso = 1,

        [Description("E-mail ou senha inválidos.")]
        EmailOuSenhaInvalidos = 2,

        [Description("Dados inválidos.")]
        DadosInvalidos = 3,

        [Description("Usuário já cadastrado no sistema.")]
        UsuarioJaCadastrado = 4,

        [Description("Email já cadastrado no sistema.")]
        EmailaCadastrado = 4,

        [Description("Ocorreu um erro não identificado na aplicação. Tente novamente mais tarde ou entre em contato com o suporte técnico")]
        ErroInterno = 99,
    }
}
