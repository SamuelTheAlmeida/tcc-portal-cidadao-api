using PortalCidadao.Domain.Enums;
using System;
using PortalCidadao.Api.Domain.Models;

namespace PortalCidadao.Domain.Models
{
	public class Postagem
	{
		public int Id { get; set; }
		public ESubcategoria Subcategoria { get; set; }
		public Categoria Categoria { get; set; }
		public int CategoriaId { get; set; }
		public string Titulo { get; set; }
		public string Descricao { get; set; }
		public string ImagemUrl { get; set; }
		public float Latitude { get; set; }
		public float Longitude { get; set; }
		public string Bairro { get; set; }
		public DateTime DataCadastro { get; set; }
		public bool Resolvido { get; set; }
        public int UsuarioId { get; set; }
		public Usuario Usuario { get; set; }
		public long Curtidas { get; set; }
		public long Descurtidas { get; set; }
    }
}


