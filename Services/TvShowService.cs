using System.Collections.Generic;
using System.Linq;
using TvShowsAPI.Models;

namespace TvShowsAPI.Services
{
    /// <summary>
    /// Implementación concreta de ITvShowService para la gestión de programas de televisión.
    /// </summary>
    public class TvShowService : ITvShowService
    {
        private readonly List<TvShow> _tvShows;

        public TvShowService()
        {
            // Inicialización con algunos datos de ejemplo
            _tvShows = new List<TvShow>
            {
                new TvShow { Id = 1, Name = "Stranger Things", Favorite = true },
                new TvShow { Id = 2, Name = "The Mandalorian", Favorite = false },
                new TvShow { Id = 3, Name = "Breaking Bad", Favorite = true }
            };
        }

        /// <summary>
        /// Obtiene todos los programas de televisión.
        /// </summary>
        /// <returns>Lista de todos los programas de televisión.</returns>
        public List<TvShowDto> GetAll()
        {
            return _tvShows.Select(t => MapToDto(t)).ToList();
        }

        /// <summary>
        /// Obtiene un programa de televisión por su Id.
        /// </summary>
        /// <param name="id">Id del programa de televisión.</param>
        /// <returns>Programa de televisión correspondiente al Id especificado.</returns>
        public TvShowDto GetById(int id)
        {
            var tvShow = _tvShows.FirstOrDefault(t => t.Id == id);
            return tvShow != null ? MapToDto(tvShow) : null;
        }

        /// <summary>
        /// Agrega un nuevo programa de televisión.
        /// </summary>
        /// <param name="tvShowDto">Datos del nuevo programa de televisión a agregar.</param>
        /// <returns>El programa de televisión agregado.</returns>
        public TvShowDto Add(CreateTvShowDto tvShowDto)
        {
            var tvShow = new TvShow
            {
                Id = _tvShows.Max(t => t.Id) + 1,
                Name = tvShowDto.Name,
                Favorite = tvShowDto.Favorite
            };

            _tvShows.Add(tvShow);
            return MapToDto(tvShow);
        }

        /// <summary>
        /// Actualiza un programa de televisión existente.
        /// </summary>
        /// <param name="tvShowDto">Nuevos datos del programa de televisión a actualizar.</param>
        /// <returns>El programa de televisión actualizado.</returns>
        public TvShowDto Update(UpdateTvShowDto tvShowDto)
        {
            var existingShow = _tvShows.FirstOrDefault(t => t.Id == tvShowDto.Id);
            if (existingShow != null)
            {
                existingShow.Name = tvShowDto.Name;
                existingShow.Favorite = tvShowDto.Favorite;
                return MapToDto(existingShow);
            }
            return null;
        }

        /// <summary>
        /// Elimina un programa de televisión por su Id.
        /// </summary>
        /// <param name="id">Id del programa de televisión a eliminar.</param>
        /// <returns>True si se eliminó correctamente; de lo contrario, false.</returns>
        public bool Delete(int id)
        {
            var existingShow = _tvShows.FirstOrDefault(t => t.Id == id);
            if (existingShow != null)
            {
                _tvShows.Remove(existingShow);
                return true;
            }
            return false;
        }

        private TvShowDto MapToDto(TvShow tvShow)
        {
            return new TvShowDto
            {
                Id = tvShow.Id,
                Name = tvShow.Name,
                Favorite = tvShow.Favorite
            };
        }
    }
}
