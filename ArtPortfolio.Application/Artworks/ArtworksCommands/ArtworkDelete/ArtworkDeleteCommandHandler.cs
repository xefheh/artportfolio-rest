using ArtPortfolio.Persistence.Common.Interfaces;
using MediatR;

namespace ArtPortfolio.Application.Artworks.ArtworksCommands.ArtworkDelete;

public class ArtworkDeleteCommandHandler(IArtworkRepository repository) : IRequestHandler<ArtworkDeleteCommand>
{
    public async Task Handle(ArtworkDeleteCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteArtworkAsync(request.Id, cancellationToken);
    }
}