using MediatR;
using MongoDB.Bson;

namespace ArtPortfolio.Application.Artworks.ArtworksCommands.ArtworkDelete;

public class ArtworkDeleteCommand : IRequest
{
    public string Id { get; set; }
}