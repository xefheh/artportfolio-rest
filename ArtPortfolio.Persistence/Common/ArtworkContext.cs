using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Persistence.Common.Exceptions;
using ArtPortfolio.Persistence.Common.Interfaces;
using ArtPortfolio.Persistence.Common.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtPortfolio.Persistence.Common;

public class ArtworkContext : IArtworkContext
{
    private readonly IMongoDatabase _database;
    
    private static readonly List<string> CollectionPropertyNames = typeof(ArtworkContext)
            .GetProperties()
            .Where(property => property.PropertyType.GetGenericTypeDefinition() == typeof(IMongoCollection<>))
            .Select(property => property.Name)
            .ToList();

    public ArtworkContext(ConnectionOptions options)
    {
        var client = new MongoClient(options.ConnectionString);
        _database = client.GetDatabase(options.DatabaseName);
        if(!_database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000))
            throw new ConnectionException(options.ConnectionString);
        EnsureCreated();
    }

    public IMongoCollection<Artwork> Artworks => 
        _database.GetCollection<Artwork>(nameof(Artworks));

    private void EnsureCreated()
    {
        var collectionNames = _database.ListCollectionNames().ToList();
        foreach (var name in CollectionPropertyNames.Where(name => !collectionNames.Contains(name)))
            _database.CreateCollection(name);
    }
}