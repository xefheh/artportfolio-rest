using ArtPortfolio.Domain.Common.Abstracts;
using ArtPortfolio.Domain.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtPortfolio.Domain.Entities;

public class Artwork : UpdatableEntity<Artwork>
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public byte[] ImageArray { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime UploadDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public IList<string> AnotherUrls { get; set; } = new List<string>();
}