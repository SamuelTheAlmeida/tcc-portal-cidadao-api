public class Postagem
{
	private int Id;

	private short Subcategoria;

	private string Titulo;

	private string Descricao;

	private string ImagemUrl;

	private float Latitude;

	private float Longitude;

	private string Bairro;

	private datetime DataCadastro;

	private boolean Resolvido;

	public void inserirPostagem(Postagem postagem)
	{

	}

	public List<Postagem> listarPorLocal(float latitude, float longitude)
	{
		return null;
	}

	public List<Postagem> listarPorBairro(string bairro)
	{
		return null;
	}

	public void remover(int postagemId)
	{

	}

	public Postagem buscar(int postagemId)
	{
		return null;
	}

	public void resolver(int postagemId)
	{

	}

}

