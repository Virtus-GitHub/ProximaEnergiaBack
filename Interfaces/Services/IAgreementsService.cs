using ProximaEnergia.Models;

namespace ProximaEnergia.Interfaces.Services
{
    public interface IAgreementsService
    {
        Task<IList<AcuerdosComercialesDTO>> GetAllAgreements();
        Task<AcuerdosComercialesDTO> CreateNewAgreement(AcuerdosComercialesDTO agrement);
        Task<List<AcuerdosComercialesDTO>> DeleteAgreementList(List<AcuerdosComercialesDTO> agrementList);
        Task<AcuerdosComercialesDTO> UpdateAgreement(AcuerdosComercialesDTO model);
    }
}
