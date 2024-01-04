using ArtPortfolio.Domain.Entities;
using MongoDB.Bson;

namespace ArtPortfolio.Persistence.Common.Interfaces;

public interface IArtworkRepository
{
    Task<Artwork> GetArtworkAsync(ObjectId id, CancellationToken cancellationToken);
    Task<IList<Artwork>> GetArtworksAsync(CancellationToken cancellationToken);
    Task<int> UpdateArtworkAsync(Artwork updatedArtwork, CancellationToken cancellationToken);
    Task<int> DeleteArtworkAsync(ObjectId id, CancellationToken cancellationToken);
    Task<ObjectId> AddArtworkAsync(Artwork artwork, CancellationToken cancellationToken);
}