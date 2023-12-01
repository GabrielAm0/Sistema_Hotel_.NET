using Sistema_Hotel.NET.Model;

Console.WriteLine("Seja bem vindo ao sistema de hotelaria!");
int opcao;
string? resposta = null;

// Iniciando as Lists
List<Hospede> hospedes = new List<Hospede>();
List<Suite> suites = new List<Suite>();
List<GrupoHospedes> gruposHospedes = new List<GrupoHospedes>();
List<GrupoSuite> gruposSuites = new List<GrupoSuite>();
List<GrupoReservas> gruposReserva = new List<GrupoReservas>();


do
{
	Console.WriteLine("\nEscolha uma opção:");
	Console.WriteLine("1. Cadastrar um grupo de hóspedes");
	Console.WriteLine("2. Cadastrar Suite");
	Console.WriteLine("3. Grupos de Hóspede cadastrados");
	Console.WriteLine("4. Suites cadastradas");
	Console.WriteLine("5. Fazer reserva");
	Console.WriteLine("6. Sair");

	opcao = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());


	switch (opcao)
	{
		case 1:
			CadastrarGrupoHospede(resposta ?? throw new InvalidOperationException());
			break;

		case 2:
			CadastrarSuites(resposta ?? throw new InvalidOperationException());
			break;

		case 3:
			HospedesCadastrados();
			break;

		case 4:
			SuitesCadastradas();
			break;

		case 5:
			FazerReserva();
			break;
	}
} while (opcao != 6);


void CadastrarGrupoHospede(string resposta)
{
	do
	{
		GrupoHospedes grupo = new GrupoHospedes();
		do
		{
			grupo.CadastrarHospedeNoQuarto(hospedes);
			Console.WriteLine("\nVocê deseja cadastrar mais algum hóspede neste grupo? (S/N)");
			resposta = Console.ReadLine() ?? throw new InvalidOperationException();

			if (resposta?.ToUpper() != "S")
			{
				break;
			}
		} while (true);

		gruposHospedes.Add(grupo);

		break;
	} while (true);
}


void CadastrarSuites(string resposta)
{
	do
	{
		GrupoSuite suite = new GrupoSuite();
		do
		{
			suite.CadastrarSuites(suites);
			Console.WriteLine("\nVocê deseja cadastrar mais suítes? (S/N)");
			resposta = Console.ReadLine() ?? throw new InvalidOperationException();

			if (resposta?.ToUpper() != "S")
			{
				break;
			}
		} while (true);

		gruposSuites.Add(suite);

		break;
	} while (true);
}

void HospedesCadastrados()
{
	Console.WriteLine("\nHóspedes cadastrados:");
	foreach (var gp in gruposHospedes)
	{
		Console.WriteLine($"Nome do Grupo: {gp.Nome}, Quantidade de Hóspedes: {gp.VerificaQuantidadeHospedes(hospedes)}");
	}
}

void SuitesCadastradas()
{
	Console.WriteLine("\nSuites cadastradas:");
	foreach (var s in suites)
	{
		string texto = "Tipo da suíte: " + s.TipoSuite + "\n" + "Capacidade: " + s.Capacidade;

		Console.WriteLine(texto);
	}
}

void FazerReserva()
{
	do
	{
		GrupoReservas reservas = new GrupoReservas();
		do
		{
			Console.WriteLine("\nQual grupo de hóspedes deseja fazer a reserva?");
			int cont = 0;
			foreach (var gp in gruposHospedes)
			{
				Console.WriteLine($"{cont + 1} - Nome do Grupo: {gp.Nome}, Quantidade de Hóspedes: {gp.VerificaQuantidadeHospedes(hospedes)}");
			}

			int escolhaHospedes = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
			escolhaHospedes = escolhaHospedes - 1;
			var grupoSelecionado = gruposHospedes.ElementAt(escolhaHospedes);


			Console.WriteLine("\nQual suíte deseja reservar?");
			foreach (var su in suites)
			{
				Console.WriteLine($"{cont + 1} - Tipo da suíte: {su.TipoSuite}, Capacidade: {su.Capacidade}");
			}

			int escolhaSuite = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
			escolhaSuite = escolhaSuite - 1;
			var suiteSelecionada = suites.ElementAt(escolhaSuite);

			if (grupoSelecionado.VerificaQuantidadeHospedes(hospedes) <= suiteSelecionada.Capacidade)
			{
				Console.WriteLine("\nQuantidade de hóspedes válida para a capacidade da suíte.");

				Console.WriteLine("\nQual o valor da diária?");
				decimal valorDiaria = decimal.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

				Console.WriteLine("\nQuantos dias deseja reservar?");
				int diasReservados = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

				if (diasReservados >= 10)
				{
					valorDiaria = valorDiaria - (valorDiaria * 0.1m);
				}

				Reserva reserva = new Reserva(grupoSelecionado.Hospedes, suiteSelecionada, diasReservados, valorDiaria);
				reservas.Reservas.Add(reserva);
				gruposReserva.Add(reservas);

				foreach (var item in gruposReserva)
				{
					foreach (var rFe in item.Reservas)
					{
						Console.Write("Hóspedes: ");
						int count = 0;

						foreach (var n in rFe.Hospedes!)
						{
							string nome = $"{n.Nome} {n.Sobrenome}";
							Console.Write(nome);

							if (++count < rFe.Hospedes.Count)
							{
								Console.Write(", ");
							}
						}

						Console.WriteLine($"\nTipo da suíte: {rFe.Suite?.TipoSuite}\n" +
						                  $"Dias Reservados: {rFe.DiasReservados}\n" +
						                  $"Valor a pagar: R${rFe.ValorAPagar}");
					}
				}
				break;
			}
			else
			{
				Console.WriteLine("\nQuantidade de hóspedes excede a capacidade da suíte. Escolha novamente.");
			}
		} while (true);

		break;
	} while (true);
}