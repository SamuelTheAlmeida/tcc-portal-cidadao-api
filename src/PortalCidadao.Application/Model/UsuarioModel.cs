using System;

namespace PortalCidadao.Application.Model
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? PerfilId { get; set; }
        public EnumModel Perfil { get; set; }
        public string Token { get; set; }
    }
}
