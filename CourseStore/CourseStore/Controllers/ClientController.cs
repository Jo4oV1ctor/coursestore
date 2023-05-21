using CourseStore.Domain.Entities;
using CourseStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.Controllers
{
    [Route("/api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService();
        }

        [HttpGet("GetAllClients")]
        public List<Client> GetAllClients()
        {
            return _clientService.GetAllClients();
        }

        [HttpGet("GetClient{id}")]
        public Client GetClient(int id)
        {
            return _clientService.GetClient(id);
        }

        [HttpPost("AddClient")]
        public void AddClient([FromBody] Client client)
        {
            _clientService.AddClient(client);
        }

        [HttpPut("UpdateClient")]
        public void UpdateClient([FromBody] Client client)
        {
            _clientService.UpdateClient(client);
        }

        [HttpDelete("RemoveClient{id}")]
        public void RemoveClient(int id)
        {
            _clientService.RemoveClient(id);
        }
    }
}
