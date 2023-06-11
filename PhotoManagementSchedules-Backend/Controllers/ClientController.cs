using Microsoft.AspNetCore.Mvc;

using PhotoManagementSystem.Application.Interfaces;
using PhotoManagementSystem.Application.Models.ClientDtos;
using PhotoManagementSystem.Application.Models.UserDtos;
using PhotoManagementSystem.Application.Services;

namespace PhotoManagementSchedules_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClinetService clientService;

        public ClientController(IClinetService clientService)
        {
            this.clientService = clientService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterClient(ClientRegisterDto clientDto)
        {
            try { 
            var clientId = await clientService.Register(clientDto);

            return Ok(clientId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = await clientService.GetClientById(id);
            return Ok(client);
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteClientById(Guid id)
        {
            await clientService.DeleteClientById(id);

            return NoContent();
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(ClientLoginDto clientLoginDto)
        {
            var clientLoginResponse = await clientService.Login(clientLoginDto);

            return Ok(clientLoginResponse);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateClient(ClientDto clientDto, Guid id)
        {
            var clientId = await clientService.UpdateClient(clientDto, id);

            return Ok(clientId);
        }
    }
}