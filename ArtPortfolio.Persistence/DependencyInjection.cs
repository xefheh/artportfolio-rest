using ArtPortfolio.Persistence.Common;
using ArtPortfolio.Persistence.Common.Interfaces;
using ArtPortfolio.Persistence.Common.Options;
using ArtPortfolio.Persistence.Repositories;
using ArtPortfolio.Persistence.Repositories.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ArtPortfolio.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionOptions = new ConnectionOptions();
        configuration.GetSection("DbConnectionOptions").Bind(connectionOptions);
        
        services.AddTransient<IArtworkContext, ArtworkContext>(provider =>
        {
            var logger = provider.GetRequiredService<ILogger<ArtworkContext>>();
            return new ArtworkContext(connectionOptions, logger);
        });
        
        services.AddTransient<IArtworkRepository, ArtworkRepository>();

        services.Decorate<IArtworkRepository, LogArtworkRepository>();
    }
}