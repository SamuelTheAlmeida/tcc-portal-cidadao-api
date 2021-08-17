using System.ComponentModel.DataAnnotations;

namespace PortalCidadao.Application.Model
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
