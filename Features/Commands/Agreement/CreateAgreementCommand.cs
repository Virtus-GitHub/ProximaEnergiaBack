using MediatR;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Commands.Agreement
{
    public class CreateAgreementCommand(AcuerdosComercialesDTO agreement) : IRequest<AcuerdosComercialesDTO>
    {
        public AcuerdosComercialesDTO _agreement = agreement;
    }
}
