﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProximaEnergia.Features.Queries.ConsumptionRates;
using ProximaEnergia.Models;

namespace ProximaEnergia.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConsumptionRatesMediatorController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<TarifasConsumoDTO>> GetConsumptionRates()
            => await _mediator.Send(new GetConsumptionRatesQuery());
    }
}
