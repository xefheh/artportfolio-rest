using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Persistence.Common.Exceptions;
using ArtPortfolio.Persistence.Common.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtPortfolio.Persistence.Repositories;

public class ArtworkRepository(IArtworkContext context) : IArtworkRepository
{
    private readonly IMongoCollection<Artwork> _collection = context.Artworks;

    public async Task<Artwork> GetArtworkAsync(ObjectId id, CancellationToken cancellationToken)
    {
        var artwork = await _collection
            .Find(artwork => artwork.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (artwork == null) throw new DbNotFoundException(nameof(Artwork), id);

        return artwork;
    }

    public async Task<IList<Artwork>> GetArtworksAsync(CancellationToken cancellationToken)
    {
        var cursor = await _collection
            .FindAsync(_ => true, cancellationToken: cancellationToken);
        var artworks = await cursor.ToListAsync(cancellationToken);
        return artworks;
    }

    public async Task<int> UpdateArtworkAsync(Artwork updatedArtwork, CancellationToken cancellationToken)
    {
        var result = await _collection
            .ReplaceOneAsync(artwork => (artwork as Artwork).Id == updatedArtwork.Id,
                updatedArtwork,
                cancellationToken: cancellationToken);
        return result.UpsertedId.AsInt32;
    }

    public async Task<int> DeleteArtworkAsync(ObjectId id, CancellationToken cancellationToken)
    {
        await _collection
            .DeleteOneAsync(artwork => (artwork as Artwork).Id == id,
                cancellationToken);
        return 0;
    }

    public async Task<ObjectId> AddArtworkAsync(Artwork artwork, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(artwork,
            new InsertOneOptions(), cancellationToken);
        return artwork.Id;
    }
}