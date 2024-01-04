using ArtPortfolio.Domain.Common.Abstracts;
using ArtPortfolio.Domain.Common.Attributes;
using MongoDB.Bson;

namespace ArtPortfolio.Domain.Entities;

public class Artwork : UpdatableEntity<Artwork>
{
    public ObjectId Id { get; set; }
    
    [Updatable]
    public byte[] ImageArray { get; set; } = null!;
    
    [Updatable]

    public string Title { get; set; } = null!;
    
    [Updatable]
    public string Description { get; set; } = null!;
    public DateTime UploadDate { get; set; }
    
    [Updatable]
    public DateTime? UpdateDate { get; set; }
    
    [Updatable]
    public IList<string> AnotherUrls { get; set; } = new List<string>();
}