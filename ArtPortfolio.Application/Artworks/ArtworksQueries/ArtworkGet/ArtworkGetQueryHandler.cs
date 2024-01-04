using ArtPortfolio.Application.Models;
using ArtPortfolio.Persistence.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace ArtPortfolio.Application.Artworks.ArtworksQueries.ArtworkGet;

public class ArtworkGetQueryHandler(IArtworkRepository repository, IMapper mapper) 
    : IRequestHandler<ArtworkGetQuery, ArtworkDetails>
{
    public async Task<ArtworkDetails> Handle(ArtworkGetQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var artwork = await repository.GetArtworkAsync(id, cancellationToken);
        return mapper.Map<ArtworkDetails>(artwork);
    }
}