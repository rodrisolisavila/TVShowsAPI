using System.Collections.Generic;
using TvShowsAPI.Models;

namespace TvShowsAPI.Services
{
    /// <summary>
    /// Interfaz para el servicio de gestión de programas de televisión.
    /// </summary>
    public interface ITvShowService
    {
        /// <summary>
        /// Obtiene todos los programas de televisión.
        /// </summary>
        /// <returns>Lista de todos los programas de televisión.</returns>
        List<TvShowDto> GetAll();

        /// <summary>
        /// Obtiene un programa de televisión por su Id.
        /// </summary>
        /// <param name="id">Id del programa de televisión.</param>
        /// <returns>Programa de televisión correspondiente al Id especificado.</returns>
        TvShowDto GetById(int id);

        /// <summary>
        /// Agrega un nuevo programa de televisión.
        /// </summary>
        /// <param name="tvShowDto">Datos del nuevo programa de televisión a agregar.</param>
        /// <returns>El programa de televisión agregado.</returns>
        TvShowDto Add(CreateTvShowDto tvShowDto);

        /// <summary>
        /// Actualiza un programa de televisión existente.
        /// </summary>
        /// <param name="tvShowDto">Nuevos datos del programa de televisión a actualizar.</param>
        /// <returns>El programa de televisión actualizado.</returns>
        TvShowDto Update(UpdateTvShowDto tvShowDto);

        /// <summary>
        /// Elimina un programa de televisión por su Id.
        /// </summary>
        /// <param name="id">Id del programa de televisión a eliminar.</param>
        /// <returns>True si se eliminó correctamente; de lo contrario, false.</returns>
        bool Delete(int id);
    }
}
