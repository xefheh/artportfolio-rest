using ArtPortfolio.Application.Models;
using MediatR;
using MongoDB.Bson;

namespace ArtPortfolio.Application.Artworks.ArtworksQueries.ArtworkGet;

public class ArtworkGetQuery : IRequest<ArtworkDetails>
{
    public string Id { get; set; }
}