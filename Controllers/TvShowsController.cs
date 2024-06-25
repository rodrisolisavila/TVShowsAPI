using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TvShowsAPI.Models;
using TvShowsAPI.Services;

namespace TvShowsAPI.Controllers
{
    /// <summary>
    /// Controlador para la gestión de programas de televisión.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TvShowsController : ControllerBase
    {
        private readonly ITvShowService _tvShowService;

        /// <summary>
        /// Constructor del controlador TvShowsController.
        /// </summary>
        /// <param name="tvShowService">Servicio de gestión de programas de televisión.</param>
        public TvShowsController(ITvShowService tvShowService)
        {
            _tvShowService = tvShowService;
        }

        /// <summary>
        /// Obtiene todos los programas de televisión.
        /// </summary>
        [HttpGet]
        public ActionResult<List<TvShowDto>> GetAll()
        {
            var tvShows = _tvShowService.GetAll();
            return Ok(tvShows);
        }

        /// <summary>
        /// Obtiene un programa de televisión por su Id.
        /// </summary>
        /// <param name="id">Id del programa de televisión.</param>
        [HttpGet("{id}")]
        public ActionResult<TvShowDto> GetById(int id)
        {
            var tvShow = _tvShowService.GetById(id);
            if (tvShow == null)
            {
                return NotFound();
            }
            return Ok(tvShow);
        }

        /// <summary>
        /// Agrega un nuevo programa de televisión.
        /// </summary>
        /// <param name="tvShowDto">Datos del nuevo programa de televisión a agregar.</param>
        [HttpPost]
        public ActionResult<TvShowDto> Add(CreateTvShowDto tvShowDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedShow = _tvShowService.Add(tvShowDto);
            return CreatedAtAction(nameof(GetById), new { id = addedShow.Id }, addedShow);
        }

        /// <summary>
        /// Actualiza un programa de televisión existente.
        /// </summary>
        /// <param name="id">Id del programa de televisión a actualizar.</param>
        /// <param name="tvShowDto">Nuevos datos del programa de televisión.</param>
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateTvShowDto tvShowDto)
        {
            if (id != tvShowDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedShow = _tvShowService.Update(tvShowDto);
            if (updatedShow == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Elimina un programa de televisión por su Id.
        /// </summary>
        /// <param name="id">Id del programa de televisión a eliminar.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _tvShowService.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
