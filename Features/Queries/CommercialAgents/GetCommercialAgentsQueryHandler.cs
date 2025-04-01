using MediatR;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Queries.CommercialAgents
{
    public class GetCommercialAgentsQueryHandler(ICommercialAgentsRepository repository) : IRequestHandler<GetCommercialAgentsQuery, IEnumerable<AgentesComercialesDTO>>
    {
        private readonly ICommercialAgentsRepository _repository = repository;
        public async Task<IEnumerable<AgentesComercialesDTO>> Handle(GetCommercialAgentsQuery request, CancellationToken cancellationToken)
            => await _repository.GetAllCommercialAgentsAsync();
    }
}
