using MediatR;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Commands.Agreement
{
    public class UpdateAgreementCommandHandler(IAgreementsRepository repository) : IRequestHandler<UpdateAgreementCommand, AcuerdosComercialesDTO>
    {
        private readonly IAgreementsRepository _repository = repository;

        public async Task<AcuerdosComercialesDTO> Handle(UpdateAgreementCommand request, CancellationToken cancellationToken)
            => await _repository.UpdateAgreementsAsync(request._agreement);
    }
}
