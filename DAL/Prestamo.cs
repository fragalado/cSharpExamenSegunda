using System;
using System.Collections.Generic;

namespace DAL;

/// <summary>
/// Entidad Prestamo que hace referencia a la tabla prestamos de la BD
/// </summary>
/// <autor>Puesto 8 (Fran Gallego)</autor>
/// Fecha: 14/12/2023
public partial class Prestamo
{

	// Atributos

	public int Idreserva { get; set; }

    public DateTime Fchreserva { get; set; }

    public virtual ICollection<RelElementoReserva> RelElementoReservas { get; set; } = new List<RelElementoReserva>();

	// Constructores

	public Prestamo(DateTime fchreserva)
	{
		Fchreserva = fchreserva;
	}
}
