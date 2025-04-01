﻿using Mapster;
using ProximaEnergia.Entity;
using ProximaEnergia.Exceptions;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;
using System.Text.Json;

namespace ProximaEnergia.Repositories
{
    public class AgreementRatesRepository(ApplicationDbContext context) : IAgreementRatesRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<List<TarifasConsumoDTO>> AddAgreementRatesAsync(List<TarifasAcuerdosDTO> agreementRates)
        {
            try
            {
                List<TarifasAcuerdo> agreementRateList = new List<TarifasAcuerdo>();

                foreach (TarifasAcuerdosDTO item in agreementRates)
                {
                    agreementRateList.Add(new TarifasAcuerdo
                    {
                        IdAcuerdo = item.IdAcuerdo,
                        IdTarifa = item.IdTarifa,
                        PorcRenovacion = 100, // no estoy seguro de si se calcula o habría que mostrar un input para que lo rellenara el comercial
                        FechaVigor = DateOnly.FromDateTime(DateTime.Now) // no estoy seguro de si se refiere a esta fecha o a un input a rellenar por el comercial
                    });
                }

                _context.TarifasAcuerdos.AddRange(agreementRateList);
                _context.SaveChanges();

                var ids = agreementRateList.Select(t => t.IdTarifa);
                var result = _context.TarifasConsumos.Where(t => ids.Contains(t.IdTarifa));

                return await Task.FromResult(result.Adapt<List<TarifasConsumoDTO>>());
            }
            catch (Exception ex)
            {
                throw new CustomException($"{ex.InnerException} ===> AddAgreementRatesAsync: {JsonSerializer.Serialize(agreementRates)}", ex.StackTrace);
            }
        }
    }
}
