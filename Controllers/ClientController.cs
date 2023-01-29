using SkiServiceApi.Models;
using SkiServiceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace SkiServiceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    //private IRegistrationService _registrationService;
    //private readonly ILogger<RegistrationController> _logger;

    private readonly ClientService _clientService;

    public ClientController(ClientService clientService) => _clientService = clientService;

    [HttpGet]
    public async Task<List<Client>> Get() => await _clientService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Client>> Get(string id)
    {
        var client = await _clientService.GetAsync(id);

        if (client is null)
        {
            return NotFound();
        }

        return client;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Client newClient)
    {
        await _clientService.CreateAsync(newClient);

        return CreatedAtAction(nameof(Get), new { id = newClient._id }, newClient);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Client updatedClient)
    {
        var client = await _clientService.GetAsync(id);

        if (client is null)
        {
            return NotFound();
        }

        updatedClient._id = client._id;

        await _clientService.UpdateAsync(id, updatedClient);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var client = await _clientService.GetAsync(id);

        if (client is null)
        {
            return NotFound();
        }

        await _clientService.RemoveAsync(id);

        return NoContent();
    }
}
