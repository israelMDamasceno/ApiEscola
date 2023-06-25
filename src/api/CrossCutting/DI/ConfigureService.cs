using Domain.Command;
using Domain.Entities;
using Domain.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;

namespace CrossCutting.DI
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUsuarioService, UsuarioService>();
            serviceCollection.AddTransient<ICursoService, CursoService>();
            serviceCollection.AddTransient<ITurmaService, TurmaService>();

            serviceCollection.AddAutoMapper(c =>
            {
                c.CreateMap<UsuarioCommand, Usuario>();
                c.CreateMap<Usuario, UsuarioViewModel>();
            });
        }
    }
}
