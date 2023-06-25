using Data.Interface;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DI
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
            serviceCollection.AddScoped<ICursoRepository, CursoRepository>();
            serviceCollection.AddScoped<ITurmaRepository, TurmaRepository>();
        }
    }
}
