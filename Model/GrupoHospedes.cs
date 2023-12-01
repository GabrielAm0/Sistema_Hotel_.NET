namespace Sistema_Hotel.NET.Model
{
	public class GrupoHospedes
	{
		public string? Nome { get; set; }
		public List<Hospede> Hospedes { get; set; }

		public GrupoHospedes()
		{
			Hospedes = new List<Hospede>();
			Console.WriteLine("\nDigite o nome do grupo de hóspedes:");
			Nome = Console.ReadLine();
		}

		public void CadastrarHospedeNoQuarto(List<Hospede> hospedes)
		{
			
			Console.WriteLine("\nDigite o nome de um hóspede:");
			string? nome = Console.ReadLine();

			Console.WriteLine("\nDigite o sobrenome do hóspede:");
			string? sobrenome = Console.ReadLine();

			if (nome != null && sobrenome != null)
			{
				Hospede p1 = new Hospede(nome: nome.Trim(), sobrenome: sobrenome.Trim());

				Hospedes.Add(p1);
			}
		}

		public int VerificaQuantidadeHospedes(List<Hospede> hospedes)
		{
			return Hospedes.Count();
		}
	}
}