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
        private readonly MittarbieterService _mittarbeiterService;
        public MitarbeiterController(MittarbieterService mittarbieterService) => _mittarbeiterService = mittarbieterService;

        [HttpGet]
        public async Task<List<Mitarbeiter>> Get() => await _mittarbeiterService.GetAsync();
    }
}
