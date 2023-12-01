namespace Sistema_Hotel.NET.Model;

public class Hospede
{
	public string? Nome { get; set; }
	public string? Sobrenome { get; set; }
	public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();

	public Hospede(string nome)
	{
		Nome = nome;
	}

	public Hospede(string nome, string sobrenome)
	{
		Nome = nome;
		Sobrenome = sobrenome;
	}
}