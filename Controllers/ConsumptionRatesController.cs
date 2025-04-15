using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProximaEnergia.Interfaces.Services;
using ProximaEnergia.Models;

namespace ProximaEnergia.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConsumptionRatesController(IConsumptionRatesService service) : ControllerBase
    {
        private readonly IConsumptionRatesService _service = service;

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<TarifasConsumoDTO>> GetConsumptionRates()
            => await _service.GetAllConsumptionRates();
    }
}
