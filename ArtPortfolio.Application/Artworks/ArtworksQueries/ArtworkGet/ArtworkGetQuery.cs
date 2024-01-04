using ArtPortfolio.Application.Models;
using MediatR;
using MongoDB.Bson;

namespace ArtPortfolio.Application.Artworks.ArtworksQueries.ArtworkGet;

public class ArtworkGetQuery : IRequest<ArtworkDetails>
{
    public ObjectId Id { get; set; }
}