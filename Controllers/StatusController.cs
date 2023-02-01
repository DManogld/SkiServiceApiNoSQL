using ApiKeyCustomAttributes.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiServiceApi.Models;
using SkiServiceApi.Services;

namespace SkiServiceApi.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly StatusService _statusService;
        public StatusController(StatusService statusService) => _statusService = statusService;

        [HttpGet]
        public async Task<List<Client>> Get() => await _statusService.GetAsync();
    }
}
