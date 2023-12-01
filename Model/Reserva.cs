namespace Sistema_Hotel.NET.Model;

public class Reserva
{
	public List<Hospede>? Hospedes { get; set; }
	public Suite? Suite { get; set; }
	public int DiasReservados { get; set; }
	public decimal ValorAPagar { get; set; }

	public Reserva()
	{
		Hospedes = new List<Hospede>();
	}

	public Reserva(List<Hospede> hospedes,Suite suite, int diasReservados, decimal valor)
	{
		DiasReservados = diasReservados;
		Hospedes = hospedes;
		Suite = suite;
		ValorAPagar = valor * DiasReservados;
	}
}