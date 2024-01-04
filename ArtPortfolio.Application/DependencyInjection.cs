using System.Reflection;
using ArtPortfolio.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace ArtPortfolio.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(configuration =>
            configuration.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly())));
    }
}