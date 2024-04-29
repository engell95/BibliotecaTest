using System;
using BibliotecaApi.Services.Interface;

namespace BibliotecaApi.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddAllService(this IServiceCollection services)
        {
            services.AddTransient<IAutorServices, AutorServices>();
            services.AddTransient<IEditorialServices, EditorialServices>();
            services.AddTransient<ILibroServices, LibroServices>();
            return services;
        }
    }
}
