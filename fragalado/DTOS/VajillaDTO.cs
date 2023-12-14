namespace fragalado.DTOS
{
	/// <summary>
	/// Clase VajillaDTO
	/// </summary>
	/// <autor>Puesto 8 (Fran Gallego)</autor>
	/// Fecha: 14/12/2023
	public class VajillaDTO
	{

		// Atributos

		public int Idelemento { get; set; }

		public int Cantidadelemento { get; set; }

		public string Codigoelemento { get; set; } = null!;

		public string Descripcionelemento { get; set; } = null!;

		public string Nombreelemento { get; set; } = null!;

		// Constructores

		public VajillaDTO(int cantidadelemento, string codigoelemento, string descripcionelemento, string nombreelemento)
		{
			Cantidadelemento = cantidadelemento;
			Codigoelemento = codigoelemento;
			Descripcionelemento = descripcionelemento;
			Nombreelemento = nombreelemento;
		}

		// ToString

		public string AString()
		{
			return "VajillaDTO [nombre=" + Nombreelemento + "; codigo=" + Codigoelemento + "; descripción=" + Descripcionelemento + "; cantidad=" + Cantidadelemento + "]";
		}
	}
}
