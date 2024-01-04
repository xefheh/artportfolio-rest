using ArtPortfolio.Domain.Entities;
using MongoDB.Driver;

namespace ArtPortfolio.Persistence.Common.Interfaces;

public interface IArtworkContext
{
    IMongoCollection<Artwork> Artworks { get; }
}