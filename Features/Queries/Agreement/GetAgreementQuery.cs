using ProximaEnergia.Models;
using MediatR;

namespace ProximaEnergia.Features.Queries.Agreement
{
    public class GetAgreementQuery : IRequest<IEnumerable<AcuerdosComercialesDTO>>
    {
    }
}
