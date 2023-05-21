using CourseStore.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CourseStore.Repositories
{
    public class ClientRepository
    {
        public ClientRepository()
        {
            Clients = new List<Client>();
            var clients = GetAllClients();
            if (clients == null)
            {
                SaveClients(Clients);
            }
        }

        private List<Client> Clients;

        public List<Client> GetAllClients()
        {
            return MockRepository<Client>.GetCache("Clients");
        }

        public Client GetClient(int id)
        {
            Client client = new Client();
            var listClients = GetAllClients();

            foreach (var c in listClients)
            {
                if (c.Id == id)
                {
                    client = c;
                }
            }
            if (client.Id == 0)
            {
                throw new InvalidOperationException(
                    $"O id {id} não corresponde a nenhuma entidade no banco de dados!"
                );
            }

            return client;
        }

        public void AddClient(Client client)
        {
            var listClients = GetAllClients();
            listClients.Add(client);
            SaveClients(listClients);
        }

        public void UpdateClient(Client client)
        {
            Client clientUpdate;
            var listClients = GetAllClients();

            foreach (var c in listClients)
            {
                if (c.Id == client.Id)
                {
                    c.Name = client.Name;
                    c.Email = client.Email;
                    c.BirthDate = client.BirthDate;
                }
            }
            SaveClients(listClients);
        }

        public void RemoveClient(int id)
        {
            Client clientDelete = new Client();
            var listClients = GetAllClients();

            foreach (var client in listClients)
            {
                if (client.Id == id)
                {
                    clientDelete = client;
                }
            }
            if (clientDelete.Id == id)
            {
                listClients.Remove(clientDelete);
            }
            SaveClients(listClients);
        }

        public void SaveClients(List<Client> listClients)
        {
            MockRepository<Client>.SetCache("Clients", listClients);
        }
    }
}
