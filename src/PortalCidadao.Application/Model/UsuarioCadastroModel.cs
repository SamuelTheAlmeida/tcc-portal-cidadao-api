namespace PortalCidadao.Application.Model
{
    public class UsuarioCadastroModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? PerfilId { get; set; }
    }
}

