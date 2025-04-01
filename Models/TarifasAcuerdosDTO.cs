namespace ProximaEnergia.Models
{
    public class TarifasAcuerdosDTO
    {
        public int IdAcuerdo { get; set; }

        public int? IdTarifa { get; set; }

        public int? PorcRenovacion { get; set; }

        public DateOnly? FechaVigor { get; set; }
    }
}
