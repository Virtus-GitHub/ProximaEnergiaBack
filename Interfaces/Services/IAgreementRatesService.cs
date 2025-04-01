using ProximaEnergia.Models;

namespace ProximaEnergia.Interfaces.Services
{
    public interface IAgreementRatesService
    {
        Task<List<TarifasConsumoDTO>> AddAgreementRates(List<TarifasAcuerdosDTO> agreementRates);
    }
}
