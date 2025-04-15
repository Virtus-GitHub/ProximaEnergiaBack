namespace ProximaEnergia.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> GetToken(string user);
    }
}
