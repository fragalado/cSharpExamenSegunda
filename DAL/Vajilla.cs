using System;
using System.Collections.Generic;

namespace DAL;

/// <summary>
/// Entidad Vajilla que hace referencia a la tabla vajilla de la BD
/// </summary>
/// <autor>Puesto 8 (Fran Gallego)</autor>
/// Fecha: 14/12/2023
public partial class Vajilla
{

	// Atributos

	public int Idelemento { get; set; }

    public int Cantidadelemento { get; set; }

    public string Codigoelemento { get; set; } = null!;

    public string Descripcionelemento { get; set; } = null!;

    public string Nombreelemento { get; set; } = null!;

    public virtual ICollection<RelElementoReserva> RelElementoReservas { get; set; } = new List<RelElementoReserva>();

	// Constructores

	public Vajilla(int cantidadelemento, string codigoelemento, string descripcionelemento, string nombreelemento)
	{
		Cantidadelemento = cantidadelemento;
		Codigoelemento = codigoelemento;
		Descripcionelemento = descripcionelemento;
		Nombreelemento = nombreelemento;
	}

	public Vajilla()
	{
	}
}
