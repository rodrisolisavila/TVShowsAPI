using Microsoft.Extensions.DependencyInjection;

namespace TvShowsAPI.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Agrega configuraciones adicionales de servicios.
        /// </summary>
        public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
        {
            // Implementación del manejador de excepciones global si es necesario
            // services.AddTransient<IExceptionHandlerMiddleware, ExceptionHandlerMiddleware>();

            return services;
        }
    }
}
