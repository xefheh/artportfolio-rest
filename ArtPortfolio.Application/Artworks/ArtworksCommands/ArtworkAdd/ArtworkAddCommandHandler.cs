using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Persistence.Common.Interfaces;
using MediatR;
using MongoDB.Bson;

namespace ArtPortfolio.Application.Artworks.ArtworksCommands.ArtworkAdd;

public class ArtworkAddCommandHandler(IArtworkRepository repository) : IRequestHandler<ArtworkAddCommand, ObjectId>
{
    public async Task<ObjectId> Handle(ArtworkAddCommand request, CancellationToken cancellationToken)
    {
        var artwork = new Artwork()
        {
            Title = request.Title,
            Description = request.Description,
            UploadDate = DateTime.Now,
            ImageArray = request.ImageArray
        };

        return await repository.AddArtworkAsync(artwork, cancellationToken);
    }
}