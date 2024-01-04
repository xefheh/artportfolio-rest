using ArtPortfolio.API.Controllers.Abstraction;
using ArtPortfolio.Application.Artworks.ArtworksCommands.ArtworkAdd;
using ArtPortfolio.Application.Artworks.ArtworksCommands.ArtworkDelete;
using ArtPortfolio.Application.Artworks.ArtworksCommands.ArtworkUpdate;
using ArtPortfolio.Application.Artworks.ArtworksQueries.ArtworkGet;
using ArtPortfolio.Application.Artworks.ArtworksQueries.ArtworkGetAll;
using ArtPortfolio.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ArtPortfolio.API.Controllers;

public class ArtworkController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    public async Task<ArtworkDetailsList> Get(CancellationToken cancellationToken) =>
        await Mediator.Send(new ArtworkGetAllQuery(), cancellationToken);

    [HttpGet("{id}")]
    public async Task<ArtworkDetails> Get(ObjectId id, CancellationToken cancellationToken) =>
        await Mediator.Send(new ArtworkGetQuery() { Id = id }, cancellationToken);

    [HttpPost]
    public async Task<ObjectId> Post([FromBody] ArtworkAddCommand request, CancellationToken cancellationToken) => 
        await Mediator.Send(request, cancellationToken);

    [HttpDelete("{id}")]
    public async Task Delete(ObjectId id, CancellationToken cancellationToken) =>
        await Mediator.Send(new ArtworkDeleteCommand() { Id = id }, cancellationToken);

    [HttpPut]
    public async Task Put([FromBody] ArtworkUpdateCommand request, CancellationToken cancellationToken) =>
        await Mediator.Send(request, cancellationToken);
}