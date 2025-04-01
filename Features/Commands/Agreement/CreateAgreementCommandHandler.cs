using MediatR;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Commands.Agreement
{
    public class CreateAgreementCommandHandler(IAgreementsRepository repository) : IRequestHandler<CreateAgreementCommand, AcuerdosComercialesDTO>
    {
        private readonly IAgreementsRepository _repository = repository;

        public async Task<AcuerdosComercialesDTO> Handle(CreateAgreementCommand request, CancellationToken cancellationToken)
            => await _repository.CreateAgreementsAsync(request._agreement);
    }
}
