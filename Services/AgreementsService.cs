using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Interfaces.Services;
using ProximaEnergia.Models;

namespace ProximaEnergia.Services
{
    public class AgreementsService(IAgreementsRepository repository) : IAgreementsService
    {
        private IAgreementsRepository _repository = repository;

        public async Task<AcuerdosComercialesDTO> CreateNewAgreement(AcuerdosComercialesDTO agrement)
            => await _repository.CreateAgreementsAsync(agrement);

        public async Task<List<AcuerdosComercialesDTO>> DeleteAgreementList(List<AcuerdosComercialesDTO> agrementList)
            => await _repository.DeleteAgreementsListAsync(agrementList);

        public async Task<IList<AcuerdosComercialesDTO>> GetAllAgreements()
            => await _repository.GetAllAgreementsAsync();

        public async Task<AcuerdosComercialesDTO> UpdateAgreement(AcuerdosComercialesDTO model)
            => await _repository.UpdateAgreementsAsync(model);
    }
}
