using DAL;
using fragalado.DTOS;
using Microsoft.EntityFrameworkCore;

namespace fragalado.Servicios
{
	/// <summary>
	/// Implementación de la interfaz RelElementoReservaInterfaz
	/// </summary>
	/// <autor>Puesto 8 (Fran Gallego)</autor>
	/// Fecha: 14/12/2023
	public class RelElementoReservaImpl : RelElementoReservaInterfaz
	{
		public void crearReserva(ExaDosContext contexto)
		{
			try
			{
				bool existe;
				int dia, mes, anyo;
				do
				{
					existe = false;
					// Pedimos el dia
					dia = CapturaEntero("Introduzca el dia de la reserva", 1, 31);

					// Pedimos el mes
					mes = CapturaEntero("Introduzca el mes de la reserva", 1, 12);

					// Pedimos el anyo
					anyo = CapturaEntero("Introduzca el año de la reserva", 1, 2023);

					// Comprobamos que no exista ninguna reserva con la misma fecha

					if (contexto.Prestamos.FirstOrDefault(r => r.Fchreserva.Day == dia && r.Fchreserva.Month == mes && r.Fchreserva.Year == anyo) != null)
					{
						existe = true;
                        Console.WriteLine("\n\n[ERROR-RelElementoReservaImpl-crearReserva] Error la reserva introducida ya existe");
                    }
				} while (existe);

				// Creamos la reserva (prestamo)
				Prestamo reserva = new Prestamo(new DateTime(anyo, mes, dia));

				// Hacemos el insert de la reserva
				contexto.Add<Prestamo>(reserva);
				contexto.SaveChanges();

				// Ahora vamos a pedir los elementos que se quiere meter en la reserva
				string nombre;
				do
				{
					// Limpiamos la consola
					Console.Clear();

					// Ahora mostramos por consola la lista de elementos
					ElementoInterfaz elementoInterfaz = new ElementoImpl();
					foreach (VajillaDTO aux in elementoInterfaz.devuelveStock(contexto))
					{
						Console.WriteLine(aux.AString());
					}

					// Pedimos el nombre del elemento
					Console.Write("Introduce el nombre del elemento [Para salir:0]: ");
					nombre = Console.ReadLine();

					if (!nombre.Equals("0"))
					{
						// Busca el elemento
						Vajilla elemento = contexto.Vajillas.FirstOrDefault(e => e.Nombreelemento == nombre);

						if(elemento != null)
						{
							// Ahora pediremos la cantidad de elemento
							// Pero primero vamos a comprobar si el elemento elegido ya está dentro de la reserva
							// Si está dentro de la reserva tendremos que calcular cuantos elementos le quedan
							int cantidadRestante = elemento.Cantidadelemento;
							foreach (var aux in contexto.RelElementoReservas.ToList())
							{
								if (aux.Idelemento == elemento.Idelemento && aux.Idreserva == reserva.Idreserva)
									cantidadRestante -= aux.Cantidadelemento;
							}

							// Ahora pedimos la cantidad
							int cantidad = CapturaEntero("Introduzca la cantidad del elemento", 0, cantidadRestante);

							// Una vez tenemos la cantidad, el elemento y la reserva haremos el insert a la tabla relacion
							// Si la cantidad introducida es 0 no haremos el Insert
							if (cantidad != 0)
							{
								contexto.Add<RelElementoReserva>(new RelElementoReserva(cantidad, elemento.Idelemento, reserva.Idreserva));
								contexto.SaveChanges();
							}
						}
						else
						{
							Console.WriteLine("\n\n[ERROR-RelElementoReservaImpl-crearReserva] Error el elemento introducido no existe");
							Console.ReadKey(true);
						}  
                    }
				} while (!nombre.Equals("0"));
			}
			catch (ArgumentOutOfRangeException e)
			{
                Console.WriteLine("[ERROR-RelElementoReservaImpl-crearReserva-ArgumentOutOfRangeException] Error " + e.Message);
            }
			catch (DbUpdateException e)
			{
				Console.WriteLine("[ERROR-RelElementoReservaImpl-crearReserva-DbUpdateException] Error " + e.Message);
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine("[ERROR-RelElementoReservaImpl-crearReserva-ArgumentNullException] Error " + e.Message);
			}
			catch (IOException e)
			{
				Console.WriteLine("[ERROR-RelElementoReservaImpl-crearReserva-IOException] Error " + e.Message);
			}
			catch (OutOfMemoryException e)
			{
				Console.WriteLine("[ERROR-RelElementoReservaImpl-crearReserva-OutOfMemoryException] Error " + e.Message);
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine("[ERROR-RelElementoReservaImpl-crearReserva-NullReferenceException] Error " + e.Message);
			}
		}

		/// <summary>
		/// Método que recibe un texto que mostrará por pantalla y un int minimo y maximo
		/// </summary>
		/// <param name="texto"></param>
		/// <param name="minimo"></param>
		/// <param name="maximo"></param>
		/// <returns>El numero introducido</returns>
		private int CapturaEntero(String texto, int minimo, int maximo)
		{
			int opcion;
			do
			{
                Console.Write("{0} [{1}-{2}]: ", texto, minimo ,maximo);
				opcion = Convert.ToInt32(Console.ReadLine());

				if(opcion < minimo || opcion > maximo)
				{
                    Console.WriteLine("\n\n [ERROR-RelElementoReservaImpl-CapturaEntero] La opción introducida no está dentro del rango");
					Console.ReadKey(true);
				}
            } while (opcion < minimo || opcion > maximo);

			return opcion;
		}
	}
}
