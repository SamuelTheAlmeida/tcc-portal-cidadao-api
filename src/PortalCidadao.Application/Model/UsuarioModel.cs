using System;

namespace PortalCidadao.Application.Model
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? PerfilId { get; set; }
        public EnumModel Perfil { get; set; }
        public bool EmailConfirmado { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Token { get; set; }
    }
}

