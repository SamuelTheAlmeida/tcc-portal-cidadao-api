using System;

namespace PortalCidadao.Application.Model
{
    public class PostagemModel
    {
        public int Id { get; set; }
        public EnumModel Subcategoria { get; set; }
        public CategoriaModel Categoria { get; set; }
        public int CategoriaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Bairro { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Resolvido { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }
        public long Curtidas { get; set; }
        public long Descurtidas { get; set; }
        public bool Excluida {get; set;}
        public string Confiabilidade { get; set; }
    }
}
