using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProximaEnergia.Features.Commands.Agreement;
using ProximaEnergia.Features.Queries.Agreement;
using ProximaEnergia.Models;

namespace ProximaEnergia.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AgreementMediatorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<AcuerdosComercialesDTO>> GetAgreements()
            => await _mediator.Send(new GetAgreementQuery());

        [HttpPost]
        [Authorize]
        public async Task<AcuerdosComercialesDTO> CreateNewAgreement(AcuerdosComercialesDTO agreement)
            => await _mediator.Send(new CreateAgreementCommand(agreement));

        [HttpPost]
        [Authorize]
        public async Task<List<AcuerdosComercialesDTO>> DeleteAgreementList(List<AcuerdosComercialesDTO> agreementList)
            => await _mediator.Send(new DeleteAgreementCommand(agreementList));

        [HttpPost]
        [Authorize]
        public async Task<AcuerdosComercialesDTO> UpdateAgreement(AcuerdosComercialesDTO agreement)
            => await _mediator.Send(new UpdateAgreementCommand(agreement));
    }
}
