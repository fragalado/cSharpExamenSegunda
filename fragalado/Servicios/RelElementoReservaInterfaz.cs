using DAL;

namespace fragalado.Servicios
{
	/// <summary>
	/// Interfaz que define los métodos que darán servicio a RelElementoReserva
	/// </summary>
	/// <autor>Puesto 8 (Fran Gallego)</autor>
	/// Fecha: 14/12/2023
	public interface RelElementoReservaInterfaz
	{
		/// <summary>
		/// Método que crea una reserva.
		/// Pide la fecha y crea la reserva con esa fecha.
		/// Además insertará en la base de datos en la tabla relación la reserva (Id), el elemento (id) y la cantidad de elementos 
		/// </summary>
		/// <param name="contexto">Contexto</param>
		/// <autor>Puesto 8 (Fran Gallego)</autor>
		/// Fecha: 14/12/2023
		public void crearReserva(ExaDosContext contexto);
	}
}
