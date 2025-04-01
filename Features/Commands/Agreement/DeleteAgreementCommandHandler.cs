using MediatR;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Commands.Agreement
{
    public class DeleteAgreementCommandHandler(IAgreementsRepository repository) : IRequestHandler<DeleteAgreementCommand, List<AcuerdosComercialesDTO>>
    {
        private readonly IAgreementsRepository _repository = repository;

        public async Task<List<AcuerdosComercialesDTO>> Handle(DeleteAgreementCommand request, CancellationToken cancellationToken)
            => await _repository.DeleteAgreementsListAsync(request._agreementList);
    }
}
