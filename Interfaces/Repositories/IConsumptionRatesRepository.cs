using ProximaEnergia.Models;

namespace ProximaEnergia.Interfaces.Repositories
{
    public interface IConsumptionRatesRepository
    {
        Task<List<TarifasAcuerdosDTO>> GetAllConsumptionRatesAsync();
    }
}
