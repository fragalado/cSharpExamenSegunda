using DAL;
using fragalado.DTOS;

namespace fragalado.Servicios
{
	/// <summary>
	/// Interfaz que define los métodos que darán servicio a Elemento (La entidad Vajilla)
	/// </summary>
	/// <autor>Puesto 8 (Fran Gallego)</autor>
	/// Fecha: 14/12/2023
	public interface ElementoInterfaz
	{
		/// <summary>
		/// Método que dará de alta un elemento en la base de datos (Insert).
		/// Pedirá los datos del elemento
		/// El código del elemento lo creará a partir de una concatenación entre "Elem-" + nombre.
		/// </summary>
		/// <autor>Puesto 8 (Fran Gallego)</autor>
		/// Fecha: 14/12/2023
		public void DarDeAltaElemento(ExaDosContext contexto);

		/// <summary>
		/// Método que devuelva una lista de todos los elementos que hay en la base de datos.
		/// </summary>
		/// <returns>Lista de objetos VajillaDTO</returns>
		/// <autor>Puesto 8 (Fran Gallego)</autor>
		/// Fecha: 14/12/2023
		public List<VajillaDTO> devuelveStock(ExaDosContext contexto);
	}
}
