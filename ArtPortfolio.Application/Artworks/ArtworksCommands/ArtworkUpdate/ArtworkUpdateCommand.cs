using MediatR;
using MongoDB.Bson;

namespace ArtPortfolio.Application.Artworks.ArtworksCommands.ArtworkUpdate;

public class ArtworkUpdateCommand : IRequest
{
    public string Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public byte[] ImageArray { get; set; } = null!;
    public DateTime UploadDate { get; set; }
    public IList<string>? AnotherUrls { get; set; }
}