using MediatR;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Interfaces.Services;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Queries.ConsumptionRates
{
    public class GetConsumptionRatesQueryHandler(IConsumptionRatesRepository repository) : IRequestHandler<GetConsumptionRatesQuery, IEnumerable<TarifasAcuerdosDTO>>
    {
        private readonly IConsumptionRatesRepository _repository = repository;

        public async Task<IEnumerable<TarifasAcuerdosDTO>> Handle(GetConsumptionRatesQuery request, CancellationToken cancellationToken)
            => await _repository.GetAllConsumptionRatesAsync();
    }
}
