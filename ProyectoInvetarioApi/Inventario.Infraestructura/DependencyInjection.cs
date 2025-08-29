using Inventario.Infraestructura.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inventario.Infraestructura
{
 

    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(configuration));

            services.AddScoped<Inventario.Dominio.Repositorio.IUserRepository, Inventario.Infraestructura.Repositorio.UserRepository>();

            //services.AddTransient<IUnitOfWork, DapperUnitOfWork>(c => new DapperUnitOfWork(connectionString));

            services.AddSingleton(new SQLServerConnection(connectionString));
         

            // Inyectar LogServices con el ILogger correctamente
          

            return services;
        }

    }
}
