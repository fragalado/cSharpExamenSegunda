using DAL;
using fragalado.DTOS;
using fragalado.Models;
using fragalado.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fragalado.Controladores
{
	public class HomeController : Controller
	{
		private readonly ExaDosContext contexto;

		public HomeController(ExaDosContext contexto)
		{
			this.contexto = contexto;

			// Inicializamos la interfaz Menu
			MenuInterfaz menuInterfaz = new MenuImpl();

			// Inicializamos la interfaz Elemento
			ElementoInterfaz elementoInterfaz = new ElementoImpl();

			// Inicializamos la interfaz RelElementoReservaInterfaz
			RelElementoReservaInterfaz relInterfaz = new RelElementoReservaImpl();

			// Mostramos el menu
			int opcion;
			do
			{
				opcion = -1;
				// Mostramos el menu
				try
				{
					opcion = menuInterfaz.menu();
				}
				catch (Exception e)
				{
                    Console.WriteLine("\n\n[ERROR-HomeController-HomeController] Error " + e.Message);
                }

				// Limpiamos la consola
				Console.Clear();

				switch (opcion)
				{
					case 1:
						// Dar de alta elemento
						try
						{
							elementoInterfaz.DarDeAltaElemento(contexto);
						}
						catch (Exception e)
						{
                            Console.WriteLine("\n\n[ERROR-HomeController-HomeController] Error no se ha dado de alta al elemento");
                        }
						break;
					case 2:
						// Mostrar stock
						try
						{
							foreach (VajillaDTO aux in elementoInterfaz.devuelveStock(contexto))
							{
								Console.WriteLine(aux.AString());
                            }
						}
						catch (Exception e)
						{
							Console.WriteLine("\n\n[ERROR-HomeController-HomeController] Error no se ha podido mostrar los elementos");
						}
						break;
					case 3:
						// Crear reserva
						try
						{
							relInterfaz.crearReserva(contexto);
						}
						catch (Exception e)
						{
							Console.WriteLine("\n\n[ERROR-HomeController-HomeController] Error no se ha podido crear la reserva");
						}
						break;
					case 0:
                        // Salir
                        Console.WriteLine("\n\n\nGracias por usar el gestor");
						Console.ReadKey(true);
                        break;
				}

				if(opcion != 0)
				{
                    Console.WriteLine("\n\nPulse una tecla para volver al menu");
					Console.ReadKey(true);
				}
			} while (opcion != 0);
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
