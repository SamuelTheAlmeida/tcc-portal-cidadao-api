using System;

namespace PortalCidadao.Domain.Models
{
	public class Postagem
	{
		public int Id { get; set; }
		public short Subcategoria { get; set; }
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public string ImagemUrl { get; set; }
		public float Latitude { get; set; }
		public float Longitude { get; set; }
		public string Bairro { get; set; }
		public DateTime DataCadastro { get; set; }
		public bool Resolvido { get; set; }
	}
}


