using ProximaEnergia.Models;
using MediatR;

namespace ProximaEnergia.Features.Queries.Agreement
{
    public class GetAgreementQuery(string user) : IRequest<IEnumerable<AcuerdosComercialesDTO>>
    {
        public string _user = user;
    }
}
