using Microsoft.AspNetCore.Mvc;
using ProximaEnergia.Entity;
using ProximaEnergia.Interfaces.Services;
using ProximaEnergia.Models;

namespace ProximaEnergia.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AgreementRatesController(IAgreementRatesService service) : ControllerBase
    {
        private readonly IAgreementRatesService _service = service;

        [HttpPost]
        public async Task<List<TarifasConsumoDTO>> AddAgreementRates(List<TarifasAcuerdosDTO> agreementRates)
            =>   await _service.AddAgreementRates(agreementRates);
    }
}