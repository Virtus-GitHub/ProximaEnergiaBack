using ProximaEnergia.Entity;
using ProximaEnergia.Exceptions;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;
using Mapster;

namespace ProximaEnergia.Repositories
{
    public class CommercialAgentsRepository(ApplicationDbContext context) : ICommercialAgentsRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<List<AgentesComercialesDTO>> GetAllCommercialAgentsAsync()
        {
            try
			{
                var allCommercialAgents = _context.AgentesComerciales.ToList();

                return await Task.FromResult(allCommercialAgents.Adapt<List<AgentesComercialesDTO>>());
            }
			catch (Exception ex)
			{
                throw new CustomException($"{ex.InnerException} ===> GetAllCommercialAgentsAsync", ex.StackTrace);
            }
        }
    }
}
