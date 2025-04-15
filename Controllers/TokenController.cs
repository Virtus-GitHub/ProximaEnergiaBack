using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProximaEnergia.Interfaces.Services;

namespace ProximaEnergia.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TokenController(ITokenService service) : ControllerBase
    {
        private readonly ITokenService _service = service;

        [HttpGet]
        public async Task<string> GetToken()
            => await _service.GetToken();
    }
}
