using System.Collections;

namespace Sistema_Hotel.NET.Model;

public class Suite : IEnumerable
{
	public string? TipoSuite { get; set; }
	public int? Capacidade { get; set; }


	public Suite()	{}

	public Suite(string tipoSuite, int capacidade)
	{
		TipoSuite = tipoSuite;
		Capacidade = capacidade;
	}

	public IEnumerator GetEnumerator()
	{
		throw new NotImplementedException();
	}
}