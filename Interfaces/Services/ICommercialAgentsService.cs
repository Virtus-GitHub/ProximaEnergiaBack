using ProximaEnergia.Models;

namespace ProximaEnergia.Interfaces.Services
{
    public interface ICommercialAgentsService
    {
        Task<IEnumerable<AgentesComercialesDTO>> GetCommercialAgents();
    }
}
