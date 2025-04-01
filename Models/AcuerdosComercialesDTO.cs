namespace ProximaEnergia.Models
{
    public class AcuerdosComercialesDTO
    {
        public int IdAcuerdo { get; set; }
        public int? IdAgente { get; set; }
        public int? IdTrabajador { get; set; }
        public DateOnly? FechaAlta { get; set; }
        public DateOnly? FechaBaja { get; set; }
        public string? Ambito { get; set; }
        public byte? DuracionMeses { get; set; }
        public bool? ProrrogaAutomatica { get; set; }
        public byte? DuracionProrrogaMeses { get; set; }
        public byte? Exclusividad { get; set; }
        public string? CodFormaPago { get; set; }
    }
}
