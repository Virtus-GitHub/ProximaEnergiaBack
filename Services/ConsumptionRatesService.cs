using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Interfaces.Services;
using ProximaEnergia.Models;

namespace ProximaEnergia.Services
{
    public class ConsumptionRatesService(IConsumptionRatesRepository repository) : IConsumptionRatesService
    {
        private readonly IConsumptionRatesRepository _repository = repository;

        public async Task<IList<TarifasAcuerdosDTO>> GetAllConsumptionRates()
            => await _repository.GetAllConsumptionRatesAsync();
    }
}
