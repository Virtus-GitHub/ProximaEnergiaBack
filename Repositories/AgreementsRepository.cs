using Mapster;
using ProximaEnergia.Entity;
using ProximaEnergia.Interfaces.Repositories;
using ProximaEnergia.Models;
using ProximaEnergia.Exceptions;
using System.Text.Json;

namespace ProximaEnergia.Repositories
{
    public class AgreementsRepository(ApplicationDbContext context) : IAgreementsRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Task<AcuerdosComercialesDTO> CreateAgreementsAsync(AcuerdosComercialesDTO agreement)
        {
            try
            {
                AcuerdosComerciales newAgreement = agreement.Adapt<AcuerdosComerciales>();

                _context.AcuerdosComerciales.Add(newAgreement);
                _context.SaveChanges();

                return GetAgreement(newAgreement);
            }
            catch (Exception ex)
            {
                throw new CustomException($"{ex.InnerException} ===> CreateAgreementsAsync: {JsonSerializer.Serialize(agreement)}", ex.StackTrace);
            }
        }

        public async Task<List<AcuerdosComercialesDTO>> DeleteAgreementsListAsync(List<AcuerdosComercialesDTO> agreementList)
        {
            try
            {
                // Esto yo lo haría modificando la base de datos para que eliminara en cascada, al eliminar el acuerdo se elimina de la tabla de tarifasacuerdos
                await DeleteAgreementRates(agreementList).ConfigureAwait(true);

                var agreementsToDelete = agreementList.Select(a => a.IdAcuerdo);
                List<AcuerdosComerciales> agreementListEntity = _context.AcuerdosComerciales.Where(a => agreementsToDelete.Contains(a.IdAcuerdo)).ToList();

                _context.AcuerdosComerciales.RemoveRange(agreementListEntity);
                int removed = _context.SaveChanges();

                if (removed == agreementList.Count)
                    return await Task.FromResult(new List<AcuerdosComercialesDTO>());
                else
                {
                    List<AcuerdosComerciales> agreementsDeleted = _context.AcuerdosComerciales.Where(a => agreementsToDelete.Contains(a.IdAcuerdo)).ToList();
                    return await Task.FromResult(agreementsDeleted.Adapt<List<AcuerdosComercialesDTO>>());
                }

            }
            catch (Exception ex)
            {
                throw new CustomException($"{ex.InnerException} ===> DeleteAgreementsListAsync: {JsonSerializer.Serialize(agreementList)}", ex.StackTrace);
            }
        }

        public async Task<List<AcuerdosComercialesDTO>> GetAllAgreementsAsync()
        {
            try
            {
                var allAgreements = _context.AcuerdosComerciales.ToList();

                return await Task.FromResult(allAgreements.Adapt<List<AcuerdosComercialesDTO>>());
            }
            catch (Exception ex)
            {
                throw new CustomException($"{ex.InnerException} ===> GetAllAgreementsAsync", ex.StackTrace);
            }

        }

        public async Task<AcuerdosComercialesDTO> UpdateAgreementsAsync(AcuerdosComercialesDTO model)
        {
            try
            {
                AcuerdosComerciales? agreement = _context.AcuerdosComerciales.Where(a => a.IdAcuerdo == model.IdAcuerdo).FirstOrDefault();
                agreement.IdAgente = model.IdAgente;
                agreement.IdTrabajador = model.IdTrabajador;
                agreement.FechaAlta = model.FechaAlta;
                agreement.FechaBaja = model.FechaBaja;
                agreement.Ambito = model.Ambito;
                agreement.DuracionMeses = model.DuracionMeses;
                agreement.ProrrogaAutomatica = model.ProrrogaAutomatica;
                agreement.DuracionProrrogaMeses = model.DuracionProrrogaMeses;
                agreement.Exclusividad = model.Exclusividad;
                agreement.CodFormaPago = model.CodFormaPago;

                _context.Update(agreement);
                int result = _context.SaveChanges();

                if (result != 1)
                    return await Task.FromResult(agreement.Adapt<AcuerdosComercialesDTO>());
                else
                    return await Task.FromResult(new AcuerdosComercialesDTO());
            }
            catch (Exception ex)
            {
                throw new CustomException($"{ex.InnerException} ===> UpdateAgreementsAsync: {JsonSerializer.Serialize(model)}", ex.StackTrace);
            }
        }

        private async Task<AcuerdosComercialesDTO> GetAgreement(AcuerdosComerciales model)
        {
            try
            {
                AcuerdosComercialesDTO agreement = _context.AcuerdosComerciales.Where(a => a == model).FirstOrDefault().Adapt<AcuerdosComercialesDTO>();

                return await Task.FromResult(agreement);
            }
            catch (Exception ex)
            {
                throw new CustomException($"{ex.InnerException} ===> GetAgreement: {JsonSerializer.Serialize(model)}", ex.StackTrace);
            }
        }

        private async Task DeleteAgreementRates(List<AcuerdosComercialesDTO> agreementList)
        {
            try
            {
                List<TarifasAcuerdo> agreementRates = new List<TarifasAcuerdo>();
                foreach (var item in agreementList)
                {
                    List<TarifasAcuerdo> agreementRatesDB = _context.TarifasAcuerdos.Where(a => a.IdAcuerdo == item.IdAcuerdo).ToList();
                    agreementRates.AddRange(agreementRatesDB);
                }

                _context.TarifasAcuerdos.RemoveRange(agreementRates);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CustomException($"{ex.InnerException} ===> DeleteAgreementRates: {JsonSerializer.Serialize(agreementList)}", ex.StackTrace);
            }
        }
    }
}
