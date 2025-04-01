using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProximaEnergia.Features.Commands.AgreementRates;
using ProximaEnergia.Models;

namespace ProximaEnergia.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AgreementRatesMediatorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));

        [HttpPost]
        public async Task<List<TarifasConsumoDTO>> AddAgreementRates(List<TarifasAcuerdosDTO> agreementRates)
            => await _mediator.Send(new AddAgreementRatesCommand(agreementRates));
    }
}
