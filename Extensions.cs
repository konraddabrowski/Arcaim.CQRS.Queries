using Arcaim.DI.Scanner;
using Microsoft.Extensions.DependencyInjection;

namespace Arcaim.CQRS.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddQuerySeparation(this IServiceCollection services)
        {
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.Scan(a => a.ByAppAssemblies()
                .ImplementationOf(typeof(IQueryHandler<,>))
                .WithTransientLifetime());

            return services;
        }
    }
}