using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtPortfolio.API.Controllers.Abstraction;

[ApiController]
[Route("[controller]")]
public class BaseController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;
}