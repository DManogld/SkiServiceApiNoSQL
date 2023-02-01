using SkiServiceApi.Models;
using SkiServiceApi.Services;
using Microsoft.AspNetCore.Mvc;
using ApiKeyCustomAttributes.Attributes;

namespace SkiServiceApi.Controllers;
[ApiKey]
[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    /// <summary>
    /// Client Controller Konstruktor mit instanziierung
    /// </summary>
    private readonly ClientService _clientService;
    public ClientController(ClientService clientService) => _clientService = clientService;

    /// <summary>
    /// Get Methode welche Service aufruft und Client abruft
    /// </summary>
    /// <returns>Liste von Client</returns>
    [HttpGet]
        public async Task<List<Client>> Get() => await _clientService.GetAsync();


    /// <summary>
    /// GetById Methode welche Service aufruft und Client nach id aufruft
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Client</returns>
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


    /// <summary>
    /// Post Methode welche Service aufruft und Client erstellt
    /// </summary>
    /// <param name="newClient"></param>
    /// <returns>ActionResult</returns>
    [HttpPost]
    public async Task<IActionResult> Post(Client newClient)
    {
        await _clientService.CreateAsync(newClient);

        return CreatedAtAction(nameof(Get), new { id = newClient._id }, newClient);
    }


    /// <summary>
    /// Put Methode welche Service aufruft und Client ändert
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedClient"></param>
    /// <returns>ActionResult</returns>
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


    /// <summary>
    /// Put Methode welche Service aufruft und Client löscht
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ActionResult</returns>
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
