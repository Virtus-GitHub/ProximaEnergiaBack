using ProximaEnergia.Models;

namespace ProximaEnergia.Interfaces.Repositories
{
    public interface IAgreementsRepository
    {
        Task<List<AcuerdosComercialesDTO>> GetAllAgreementsAsync();
        Task<AcuerdosComercialesDTO> CreateAgreementsAsync(AcuerdosComercialesDTO agreement);
        Task<List<AcuerdosComercialesDTO>> DeleteAgreementsListAsync(List<AcuerdosComercialesDTO> agreementList);
        Task<AcuerdosComercialesDTO> UpdateAgreementsAsync(AcuerdosComercialesDTO model);
    }
}
