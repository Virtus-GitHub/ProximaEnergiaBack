using MediatR;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Queries.ConsumptionRates
{
    public class GetConsumptionRatesQuery : IRequest<IEnumerable<TarifasConsumoDTO>>
    {
    }
}
