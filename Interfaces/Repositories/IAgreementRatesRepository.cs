using ProximaEnergia.Models;

namespace ProximaEnergia.Interfaces.Repositories
{
    public interface IAgreementRatesRepository
    {
        Task<List<TarifasConsumoDTO>> AddAgreementRatesAsync(List<TarifasAcuerdosDTO> agreementRates);
    }
}
