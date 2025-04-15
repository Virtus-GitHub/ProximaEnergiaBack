using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProximaEnergia.Features.Queries.CommercialAgents;
using ProximaEnergia.Models;

namespace ProximaEnergia.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommercialAgentsMediatorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<AgentesComercialesDTO>> GetAgents()
            => await _mediator.Send(new GetCommercialAgentsQuery());
    }
}
