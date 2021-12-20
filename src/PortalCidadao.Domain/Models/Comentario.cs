using System;

namespace PortalCidadao.Domain.Models
{
    public class Comentario
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
		public DateTime DataCadastro { get; set; }
		public int UsuarioId {get; set;}
		public int PostagemId {get; set;}
        public string NomeUsuario { get; set; }
    }
}


