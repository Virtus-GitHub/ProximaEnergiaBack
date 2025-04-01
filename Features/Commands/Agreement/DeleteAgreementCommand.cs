using MediatR;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Commands.Agreement
{
    public class DeleteAgreementCommand(List<AcuerdosComercialesDTO> agreementList) : IRequest<List<AcuerdosComercialesDTO>>
    {
        public List<AcuerdosComercialesDTO> _agreementList = agreementList;
    }
}
