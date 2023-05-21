using CourseStore.Domain.Entities;
using CourseStore.Repositories;

namespace CourseStore.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }

        public List<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public Client GetClient(int id)
        {
            if (id == 0)
            {
                throw new InvalidOperationException("O id deve ser diferente de zero.");
            }
            return _clientRepository.GetClient(id);
        }

        public void AddClient(Client client)
        {
            if (client.Id == 0)
            {
                throw new InvalidOperationException("O cliente deve ter um id diferente de zero.");
            }
            _clientRepository.AddClient(client);
        }

        public void UpdateClient(Client client)
        {
            _clientRepository.UpdateClient(client);
        }

        public void RemoveClient(int id)
        {
            _clientRepository.RemoveClient(id);
        }
    }
}
