namespace fragalado.Servicios
{
	/// <summary>
	/// Implementación de la Interfaz Menu
	/// <autor>Puesto 8 (Fran Gallego)</autor>
	/// Fecha: 14/12/2023
	/// </summary>
	public class MenuImpl : MenuInterfaz
	{
		public int menu()
		{
			int opcion;
			do
			{
				// Limpiamos la consola
				Console.Clear();
                Console.WriteLine("======================");
                Console.WriteLine("1. Alta elemento");
				Console.WriteLine("2. Mostrar stock");
				Console.WriteLine("3. Crear Reserva");
				Console.WriteLine("0. Salir");
                Console.Write("Introduce una opción: ");
				opcion = Console.ReadKey().KeyChar - '0';

				if (opcion < 0 || opcion > 3)
				{
					Console.WriteLine("\n\n[ERROR-MenuImpl-menu] Error no se ha introducido una opción correcta");
                    Console.WriteLine("Pulse una tecla para continuar");
					Console.ReadKey(true);
                }
					
            } while (opcion < 0 || opcion > 3);

			return opcion;
		}
	}
}
