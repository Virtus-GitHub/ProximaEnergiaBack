using ProximaEnergia.Models;
using MediatR;

namespace ProximaEnergia.Features.Commands.AgreementRates
{
    public class AddAgreementRatesCommand(List<TarifasAcuerdosDTO> agreementRatesList) : IRequest<List<TarifasConsumoDTO>>
    {
        public List<TarifasAcuerdosDTO> _agreementRatesList = agreementRatesList;
    }
}
