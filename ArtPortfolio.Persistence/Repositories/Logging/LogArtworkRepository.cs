using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Persistence.Common.Exceptions;
using ArtPortfolio.Persistence.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace ArtPortfolio.Persistence.Repositories.Logging;

public class LogArtworkRepository(IArtworkRepository repository, ILogger<IArtworkRepository> logger) : IArtworkRepository
{
    public async Task<Artwork> GetArtworkAsync(string id, CancellationToken cancellationToken)
    {
        logger.LogInformation("[ARTWORK REPOSITORY] Invoked get artwork from database, ID: {ObjectId}", id);
        try
        {
            var artwork = await repository.GetArtworkAsync(id, cancellationToken);
            return artwork;
        }
        catch (DbNotFoundException exception)
        {
            logger.LogError("[ARTWORK REPOSITORY] Error occured: {Exception}", exception);
            throw;
        }
    }

    public async Task<IList<Artwork>> GetArtworksAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("[ARTWORK REPOSITORY] Invoked get Artworks from database");
        return await repository.GetArtworksAsync(cancellationToken);
    }

    public async Task UpdateArtworkAsync(Artwork updatedArtwork, CancellationToken cancellationToken)
    {
        logger.LogInformation("[ARTWORK REPOSITORY] Invoked update Artwork with id: {Id}, to database",
            updatedArtwork.Id);
        try
        {
            await repository.UpdateArtworkAsync(updatedArtwork, cancellationToken);
        }
        catch (DbNotFoundException exception)
        {
            logger.LogInformation("[ARTWORK REPOSITORY] Error occured: {Exception}", exception);
            throw;
        }
    }

    public async Task DeleteArtworkAsync(string id, CancellationToken cancellationToken)
    {
        logger.LogInformation("[ARTWORK REPOSITORY] Invoked delete Artwork with id: {Id}, to database", id);
        try
        {
            await repository.DeleteArtworkAsync(id, cancellationToken);
        }
        catch (DbNotFoundException exception)
        {
            logger.LogInformation("[ARTWORK REPOSITORY] Error occured: {Exception}", exception);
            throw;
        }
    }

    public async Task<string> AddArtworkAsync(Artwork artwork, CancellationToken cancellationToken)
    {
        logger.LogInformation("[ARTWORK REPOSITORY] Invoked adding artwork with data: {Data}, to database",
            artwork);
        return await repository.AddArtworkAsync(artwork, cancellationToken);
    }
}