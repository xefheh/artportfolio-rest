using ArtPortfolio.Domain.Entities;
using MongoDB.Bson;

namespace ArtPortfolio.Persistence.Common.Interfaces;

public interface IArtworkRepository
{
    Task<Artwork> GetArtworkAsync(string id, CancellationToken cancellationToken);
    Task<IList<Artwork>> GetArtworksAsync(CancellationToken cancellationToken);
    Task UpdateArtworkAsync(Artwork updatedArtwork, CancellationToken cancellationToken);
    Task DeleteArtworkAsync(string id, CancellationToken cancellationToken);
    Task<string> AddArtworkAsync(Artwork artwork, CancellationToken cancellationToken);
}