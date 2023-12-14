using System;
using System.Collections.Generic;

namespace DAL;

/// <summary>
/// Entidad RelElementoReserva que hace referencia a la tabla relacion de la BD
/// </summary>
/// <autor>Puesto 8 (Fran Gallego)</autor>
/// Fecha: 14/12/2023
public partial class RelElementoReserva
{

	// Atributos 

	public int Idrelacion { get; set; }

    public int Cantidadelemento { get; set; }

    public int? Idelemento { get; set; }

    public int? Idreserva { get; set; }

    public virtual Vajilla? IdelementoNavigation { get; set; }

    public virtual Prestamo? IdreservaNavigation { get; set; }

	// Constructores

	public RelElementoReserva(int cantidadelemento, int? idelemento, int? idreserva)
	{
		Cantidadelemento = cantidadelemento;
		Idelemento = idelemento;
		Idreserva = idreserva;
	}

}
