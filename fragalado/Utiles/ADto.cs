using DAL;
using fragalado.DTOS;

namespace fragalado.Utiles
{
	/// <summary>
	/// Clase que contendrá los métodos para pasar de DAO a DTO
	/// </summary>
	/// <autor>Puesto 8 (Fran Gallego)</autor>
	/// Fecha: 14/12/2023
	public class ADto
	{
		/// <summary>
		/// Método que pasa una lista de objetos de tipo Vajilla (DAO) a una lista de objetos de tipo VajillaDTO
		/// </summary>
		/// <param name="listaVajillasDAO">Lista que contiene objetos de tipo Vajilla</param>
		/// <returns>Lista con objetos de tipo VajillaDTO</returns>
		public List<VajillaDTO> VajillaADto(List<Vajilla> listaVajillasDAO)
		{
			// Creamos una lista auxiliar de tipo VajillaDTO
			List<VajillaDTO> listaAuxiliar = new List<VajillaDTO>();

            // Recorremos la listaVajillasDAO
            foreach (Vajilla aux in listaVajillasDAO)
            {
				// Creamos objetos de tipo VajillaDTO y lo metemos en la lista
				listaAuxiliar.Add(new VajillaDTO(aux.Cantidadelemento, aux.Codigoelemento, aux.Descripcionelemento, aux.Nombreelemento));
            }

			// Devolvemos la lista
			return listaAuxiliar;
        }
	}
}
