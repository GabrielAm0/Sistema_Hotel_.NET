namespace Sistema_Hotel.NET.Model;

public class GrupoReservas
{
	public List<Reserva> Reservas { get; set; }


	public GrupoReservas()
	{
		Reservas = new List<Reserva>();
	}

}