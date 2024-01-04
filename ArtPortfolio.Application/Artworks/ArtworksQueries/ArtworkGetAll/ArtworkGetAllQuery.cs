using ArtPortfolio.Application.Models;
using MediatR;

namespace ArtPortfolio.Application.Artworks.ArtworksQueries.ArtworkGetAll;

public class ArtworkGetAllQuery : IRequest<ArtworkDetailsList> { }