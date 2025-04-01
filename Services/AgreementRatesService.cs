using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Interfaces.Services;
using ProximaEnergia.Models;
using System.Runtime.CompilerServices;

namespace ProximaEnergia.Services
{
    public class AgreementRatesService(IAgreementRatesRepository repository) : IAgreementRatesService
    {
        private readonly IAgreementRatesRepository _repository = repository;
        public async Task<List<TarifasConsumoDTO>> AddAgreementRates(List<TarifasAcuerdosDTO> agreementRates)
            => await _repository.AddAgreementRatesAsync(agreementRates);
    }
}
