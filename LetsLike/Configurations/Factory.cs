using LetsLike.Interfaces;
using LetsLike.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LetsLike.Configurations
{
    public class Factory
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IUsuarioLikeProjetoService, UsuarioLikeProjetoService>();
        }
    }
}
