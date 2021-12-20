using PortalCidadao.Domain.Enums;
using System;

namespace PortalCidadao.Domain.Models
{
    public class Usuario
	{
		public int Id { get; set; }
		public string CPF { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public EPerfis Perfil { get; set; }
		public bool EmailConfirmado { get; set; }
		public DateTime DataCadastro { get; set; }
		public Guid? TokenRedefinicaoSenha { get; set; }
	}
}


