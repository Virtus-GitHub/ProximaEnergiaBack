using MediatR;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Commands.Agreement
{
    public class UpdateAgreementCommand(AcuerdosComercialesDTO agreement) : IRequest<AcuerdosComercialesDTO>
    {
        public AcuerdosComercialesDTO _agreement = agreement;
    }
}
