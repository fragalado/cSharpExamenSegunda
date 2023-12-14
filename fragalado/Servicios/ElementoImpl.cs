using DAL;
using fragalado.DTOS;
using fragalado.Utiles;
using Microsoft.EntityFrameworkCore;

namespace fragalado.Servicios
{
	/// <summary>
	/// Implementación de la Interfaz Elemento
	/// </summary>
	/// <autor>Puesto 8 (Fran Gallego)</autor>
	/// Fecha: 14/12/2023
	public class ElementoImpl : ElementoInterfaz
	{
		public void DarDeAltaElemento(ExaDosContext contexto)
		{
			try
			{
				// Pedimos el nombre del elemento
				Console.Write("Introduce el nombre del elemento: ");
				string nombre = Console.ReadLine();

				// Pedimos el nombre del elemento
				Console.Write("Introduce la descripcion del elemento: ");
				string descripcion = Console.ReadLine();

				// Pedimos el nombre del elemento
				Console.Write("Introduce la cantidad del elemento: ");
				int cantidad = Convert.ToInt32(Console.ReadLine());

				// Ahora creamos un objeto Vajilla para hacer el insert a la base de datos
				// El codigo del elemento será una concatenación de "Elem-" + nombreElemento
				Vajilla elemento = new Vajilla(cantidad, "Elem-" + nombre, nombre, descripcion);
				contexto.Add<Vajilla>(elemento);
				contexto.SaveChanges();

                // Mostramos un mensaje INFO
                Console.WriteLine("\n[INFO-ElementoImpl-DarDeAltaElemento] Se ha introducido el elemento con éxito");
            }
			catch (IOException e)
			{
                Console.WriteLine("[ERROR-ElementoImpl-DarDeAltaElemento-IOException] Error " + e.Message);
            }
			catch (OutOfMemoryException e)
			{
				Console.WriteLine("[ERROR-ElementoImpl-DarDeAltaElemento-OutOfMemoryException] Error " + e.Message);
			} 
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine("[ERROR-ElementoImpl-DarDeAltaElemento-ArgumentOutOfRangeException] Error " + e.Message);
			}
			catch (FormatException e)
			{
				Console.WriteLine("[ERROR-ElementoImpl-DarDeAltaElemento-FormatException] Error " + e.Message);
			}
			catch (OverflowException e)
			{
				Console.WriteLine("[ERROR-ElementoImpl-DarDeAltaElemento-OverflowException] Error " + e.Message);
			}
			catch (DbUpdateException e)
			{
				Console.WriteLine("[ERROR-ElementoImpl-DarDeAltaElemento-DbUpdateException] Error " + e.Message);
			}
		}

		public List<VajillaDTO> devuelveStock(ExaDosContext contexto)
		{
			// Lista donde guardaremos los objetos DTO
			List<VajillaDTO> listaVajillaDTO = new List<VajillaDTO> ();

			try
			{
				ADto adto = new ADto();
				listaVajillaDTO = adto.VajillaADto(contexto.Vajillas.ToList());

				// Mensaje INFO
				Console.WriteLine("\n[INFO-ElementoImpl-devuelveStock] Cantidad: " + listaVajillaDTO.Count);
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine("[ERROR-ElementoImpl-devuelveStock-ArgumentNullException] Error " + e.Message);
			}

			return listaVajillaDTO;
		}
	}
}
