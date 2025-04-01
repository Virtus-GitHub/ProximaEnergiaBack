using MediatR;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Queries.Agreement
{
    public class GetAgreementQueryHandler(IAgreementsRepository repository) : IRequestHandler<GetAgreementQuery,IEnumerable<AcuerdosComercialesDTO>>
    {
        private readonly IAgreementsRepository _repository = repository;

        public async Task<IEnumerable<AcuerdosComercialesDTO>> Handle(GetAgreementQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAgreementsAsync();
        }
    }
}
