using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Interfaces.Services;
using ProximaEnergia.Models;
using System.Runtime.CompilerServices;

namespace ProximaEnergia.Services
{
    public class CommercialAgentsService(ICommercialAgentsRepository repository) : ICommercialAgentsService
    {
        private readonly ICommercialAgentsRepository _repository = repository;
        public async Task<IEnumerable<AgentesComercialesDTO>> GetCommercialAgents()
            => await _repository.GetAllCommercialAgentsAsync();
    }
}
