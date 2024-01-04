using ArtPortfolio.Persistence.Common;
using ArtPortfolio.Persistence.Common.Interfaces;
using ArtPortfolio.Persistence.Common.Options;
using ArtPortfolio.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtPortfolio.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionOptions = new ConnectionOptions();
        configuration.GetSection("DbConnectionOptions").Bind(connectionOptions);
        services.AddTransient<IArtworkContext, ArtworkContext>(_ => 
            new ArtworkContext(connectionOptions));
        services.AddTransient<IArtworkRepository, ArtworkRepository>();
    }
}