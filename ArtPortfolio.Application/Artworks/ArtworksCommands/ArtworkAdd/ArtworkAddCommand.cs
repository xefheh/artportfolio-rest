using MediatR;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;

namespace ArtPortfolio.Application.Artworks.ArtworksCommands.ArtworkAdd;

public class ArtworkAddCommand : IRequest<string>
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public byte[] ImageArray { get; set; } = null!;
    public IList<string>? AnotherUrls { get; set; }
}