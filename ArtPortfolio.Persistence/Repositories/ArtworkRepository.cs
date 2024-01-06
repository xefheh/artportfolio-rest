using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Persistence.Common.Exceptions;
using ArtPortfolio.Persistence.Common.Interfaces;
using MongoDB.Driver;

namespace ArtPortfolio.Persistence.Repositories;

public class ArtworkRepository(IArtworkContext context) : IArtworkRepository
{
    private readonly IMongoCollection<Artwork> _collection = context.Artworks;

    public async Task<Artwork> GetArtworkAsync(string id, CancellationToken cancellationToken)
    {
        var artwork = await _collection
            .Find(artwork => artwork.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
        if (artwork == null) 
            throw new DbNotFoundException(nameof(Artwork), id);
        return artwork;
    }

    public async Task<IList<Artwork>> GetArtworksAsync(CancellationToken cancellationToken)
    {
        var cursor = await _collection
            .FindAsync(_ => true, cancellationToken: cancellationToken);
        var artworks = await cursor.ToListAsync(cancellationToken);
        return artworks;
    }

    public async Task UpdateArtworkAsync(Artwork updatedArtwork, CancellationToken cancellationToken)
    {
        var result = await _collection
            .ReplaceOneAsync(artwork => artwork.Id == updatedArtwork.Id,
                updatedArtwork,
                cancellationToken: cancellationToken);
        if (result.ModifiedCount == 0)
            throw new DbNotFoundException(nameof(Artwork), updatedArtwork.Id);
    }

    public async Task DeleteArtworkAsync(string id, CancellationToken cancellationToken)
    {
        var result = await _collection
            .DeleteOneAsync(artwork => artwork.Id == id,
                cancellationToken);
        if (result.DeletedCount == 0)
            throw new DbNotFoundException(nameof(Artwork), id);
    }

    public async Task<string> AddArtworkAsync(Artwork artwork, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(artwork,
            new InsertOneOptions(), cancellationToken);
        return artwork.Id;
    }
}