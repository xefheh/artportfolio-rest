using ArtPortfolio.Application.Models;
using ArtPortfolio.Persistence.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace ArtPortfolio.Application.Artworks.ArtworksQueries.ArtworkGetAll;

public class ArtworkGetAllQueryHandler(IArtworkRepository repository, IMapper mapper) :
    IRequestHandler<ArtworkGetAllQuery, ArtworkDetailsList>
{
    public async Task<ArtworkDetailsList> Handle(ArtworkGetAllQuery request, CancellationToken cancellationToken)
    {
        var artworks = await repository.GetArtworksAsync(cancellationToken);
        var artworksModel = new ArtworkDetailsList()
        {
            Details = artworks
                .Select(mapper.Map<ArtworkDetails>)
                .ToList()
        };
        return artworksModel;
    }
}