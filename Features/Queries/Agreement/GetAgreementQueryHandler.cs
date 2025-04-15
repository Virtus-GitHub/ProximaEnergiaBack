using MediatR;
using ProximaEnergia.Enums;
using ProximaEnergia.Helpers;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Queries.Agreement
{
    public class GetAgreementQueryHandler(IAgreementsRepository repository) : IRequestHandler<GetAgreementQuery,IEnumerable<AcuerdosComercialesDTO>>
    {
        private readonly IAgreementsRepository _repository = repository;

        public async Task<IEnumerable<AcuerdosComercialesDTO>> Handle(GetAgreementQuery request, CancellationToken cancellationToken)
        {
            // Comprobamos que el usuario existe, se puede utilizar despúes para guardar trazas.
            UsersEnum user = UsersHelper.GetUser(request._user);

            return await _repository.GetAllAgreementsAsync();
        }
    }
}
