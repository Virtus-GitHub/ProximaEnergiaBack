using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProximaEnergia.Interfaces.Services;
using ProximaEnergia.Models;

namespace ProximaEnergia.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AgreementController(IAgreementsService service) : ControllerBase
    {
        private readonly IAgreementsService _service = service;

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<AcuerdosComercialesDTO>> GetAgreements()
            => await _service.GetAllAgreements();

        [HttpPost]
        [Authorize]
        public async Task<AcuerdosComercialesDTO> CreateNewAgreement(AcuerdosComercialesDTO agreement)
            => await _service.CreateNewAgreement(agreement);

        [HttpPost]
        [Authorize]
        public async Task<List<AcuerdosComercialesDTO>> DeleteAgreementList(List<AcuerdosComercialesDTO> agreementList)
            => await _service.DeleteAgreementList(agreementList);

        [HttpPost]
        [Authorize]
        public async Task<AcuerdosComercialesDTO> UpdateAgreement(AcuerdosComercialesDTO agreement)
            => await _service.UpdateAgreement(agreement);
    }
}
