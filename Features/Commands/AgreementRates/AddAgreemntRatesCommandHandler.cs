using MediatR;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;

namespace ProximaEnergia.Features.Commands.AgreementRates
{
    public class AddAgreemntRatesCommandHandler(IAgreementRatesRepository repository) : IRequestHandler<AddAgreementRatesCommand, List<TarifasConsumoDTO>>
    {
        private readonly IAgreementRatesRepository _repository = repository;

        public async Task<List<TarifasConsumoDTO>> Handle(AddAgreementRatesCommand request, CancellationToken cancellationToken)
            => await _repository.AddAgreementRatesAsync(request._agreementRatesList);
    }
}
