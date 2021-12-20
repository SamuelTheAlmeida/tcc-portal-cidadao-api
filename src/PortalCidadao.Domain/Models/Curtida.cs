namespace PortalCidadao.Domain.Models
{
    public class Curtida
	{
		public int Id { get; set; }
		public bool Acao { get; set; }
		public float Pontos { get; set; }
		public int UsuarioId {get; set;}
		public int PostagemId {get; set;}
	}
}
