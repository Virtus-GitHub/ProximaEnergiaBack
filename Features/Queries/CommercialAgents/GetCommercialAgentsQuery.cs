using MediatR;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Queries.CommercialAgents
{
    public class GetCommercialAgentsQuery : IRequest<IEnumerable<AgentesComercialesDTO>>
    {
    }
}
