namespace Sistema_Hotel.NET.Model;

public class GrupoSuite
{
	public List<Suite> Suites { get; set; }


	public GrupoSuite()
	{
		Suites = new List<Suite>();
	}

	public void CadastrarSuites(List<Suite> suites)
	{
		Console.WriteLine("\nDigite o tipo da suíte:");
		string tipoSuite = Console.ReadLine() ?? throw new InvalidOperationException();

		Console.WriteLine("\nDigite a capacidade da suíte:");
		int capacidadeSuite = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

		Suite s1 = new Suite(tipoSuite.Trim(), capacidadeSuite);

		suites.Add(s1);
	}
}