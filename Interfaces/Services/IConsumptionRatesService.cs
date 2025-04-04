﻿using ProximaEnergia.Models;

namespace ProximaEnergia.Interfaces.Services
{
    public interface IConsumptionRatesService
    {
        Task<IList<TarifasConsumoDTO>> GetAllConsumptionRates();
    }
}
