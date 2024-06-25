using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text;
using TvShowsAPI.Extensions;
using TvShowsAPI.Middleware;
using TvShowsAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace TvShowsApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configura los servicios de la aplicación.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de servicios MVC
            services.AddControllers();

            // Configuración de CORS para permitir cualquier origen, método y encabezado
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            // Registro de servicios Singleton
            services.AddSingleton<ITvShowService, TvShowService>();
            services.AddSingleton<IAuthService, AuthService>();

            // Configuración de autenticación JWT
            ConfigureJwtAuthentication(services);

            // Configuración de Swagger
            ConfigureSwagger(services);

            // Configuración para manejo global de excepciones
            services.AddExceptionHandler();
        }

        /// <summary>
        /// Configura la aplicación y el pipeline de solicitud HTTP.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Habilita la documentación Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TV Shows API V1");
            });

            // Configuración de excepciones en entorno de desarrollo
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Configuración de excepciones en entorno de producción
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Redirección HTTPS y manejo de archivos estáticos
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Configuración de CORS
            app.UseCors("AllowAllOrigins");

            // Middleware de enrutamiento, autenticación y autorización
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Configuración de los endpoints de la aplicación
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Configura la autenticación JWT.
        /// </summary>
        private void ConfigureJwtAuthentication(IServiceCollection services)
        {
            var jwtSettings = Configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        }

        /// <summary>
        /// Configura Swagger para la documentación de la API.
        /// </summary>
        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TV Shows API", Version = "v1" });
            });
        }
    }
}
