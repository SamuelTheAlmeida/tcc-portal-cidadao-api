using System;
using PortalCidadao.Domain.Enums;

namespace PortalCidadao.Application.Model
{
    public class PostagemModel
    {
        public int Id { get; set; }
        public ESubcategoria Subcategoria { get; set; }
        public CategoriaModel Categoria { get; set; }
        public int CategoriaId { get; set; }
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
