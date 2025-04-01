using Microsoft.AspNetCore.Mvc;
using ProximaEnergia.Interfaces.Services;
using ProximaEnergia.Models;

namespace ProximaEnergia.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommercialAgentsController(ICommercialAgentsService service) : ControllerBase
    {
        private readonly ICommercialAgentsService _service = service;

        [HttpGet]
        public async Task<IEnumerable<AgentesComercialesDTO>> GetAgents()
            => await _service.GetCommercialAgents();
    }
}
