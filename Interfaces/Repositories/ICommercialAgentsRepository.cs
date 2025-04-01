using ProximaEnergia.Models;

namespace ProximaEnergia.Interfaces.Repositories
{
    public interface ICommercialAgentsRepository
    {
        Task<List<AgentesComercialesDTO>> GetAllCommercialAgentsAsync();
    }
}
