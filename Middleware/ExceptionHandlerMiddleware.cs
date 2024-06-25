using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace TvShowsAPI.Middleware
{
    /// <summary>
    /// Middleware para el manejo global de excepciones en la aplicación.
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor del middleware ExceptionHandlerMiddleware.
        /// </summary>
        /// <param name="next">Delegado de solicitud siguiente en el pipeline.</param>
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Método Invoke para manejar las excepciones globales.
        /// </summary>
        /// <param name="context">Contexto de la solicitud HTTP.</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Implementación de manejo de excepciones aquí
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Error: " + ex.Message);
            }
        }
    }
}
