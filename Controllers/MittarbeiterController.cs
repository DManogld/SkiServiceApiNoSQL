using ApiKeyCustomAttributes.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiServiceApi.Models;
using SkiServiceApi.Services;

namespace SkiServiceApi.Controllers
{
    [ApiKey]
    [Route("[controller]")]
    [ApiController]
    public class MitarbeiterController : ControllerBase
    {
        /// <summary>
        /// Mittarbeiter Controller Konstruktor mit instanziierung
        /// </summary>
        private readonly MittarbieterService _mittarbeiterService;
        public MitarbeiterController(MittarbieterService mittarbieterService) => _mittarbeiterService = mittarbieterService;

        /// <summary>
        /// Get Methode welche Service aufruft um Mittarbeiter liste augibt
        /// </summary>
        /// <returns>Liste von Mittarbeiter</returns>
        [HttpGet]
        public async Task<List<Mitarbeiter>> Get() => await _mittarbeiterService.GetAsync();
    }
}
