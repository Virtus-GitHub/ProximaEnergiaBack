using Mapster;
using ProximaEnergia.Entity;
using ProximaEnergia.Exceptions;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;
using System.Text.Json;

namespace ProximaEnergia.Repositories
{
    public class ConsumptionRatesRepository(ApplicationDbContext context) : IConsumptionRatesRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Models.TarifasAcuerdosDTO>> GetAllConsumptionRatesAsync()
        {
            try
            {
                var consumptionRatesList = _context.TarifasConsumos.ToList();

                return await Task.FromResult(consumptionRatesList.Adapt<List<Models.TarifasAcuerdosDTO>>());
            }
            catch (Exception ex)
            {
                throw new CustomException($"{ex.InnerException} ===> GetAllAgreementFeesAsync", ex.StackTrace);
            }
        }
    }
}
