using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Persistence.Common.Interfaces;
using MediatR;

namespace ArtPortfolio.Application.Artworks.ArtworksCommands.ArtworkUpdate;

public class ArtworkUpdateCommandHandler(IArtworkRepository repository) : IRequestHandler<ArtworkUpdateCommand>
{
    public async Task Handle(ArtworkUpdateCommand request, CancellationToken cancellationToken)
    {
        var artwork = new Artwork()
        {
            Id = request.Id,
            Title = request.Title,
            UploadDate = request.UploadDate,
            UpdateDate = DateTime.Now,
            ImageArray = request.ImageArray,
            AnotherUrls = request.AnotherUrls,
            Description = request.Description
        };
        
        await repository.UpdateArtworkAsync(artwork, cancellationToken);
    }
}