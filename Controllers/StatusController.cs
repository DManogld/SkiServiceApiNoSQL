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
        /// <summary>
        /// Status Controller Konstruktor mit instanziierung
        /// </summary>
        private readonly StatusService _statusService;
        public StatusController(StatusService statusService) => _statusService = statusService;

        /// <summary>
        /// Get Methode welche Service aufruft um Client nach Status gefiltert augibt
        /// </summary>
        /// <returns>Liste von Client</returns>
        [HttpGet]
        public async Task<List<Client>> Get() => await _statusService.GetAsync();
    }
}
