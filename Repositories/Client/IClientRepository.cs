using Teste_Trinks.Models;
using System.Collections.Generic;

namespace Teste_Trinks.Repositories
{
    public interface IClientRepository<T> : IEntityFrameworkRepository<T> where T : IClient
    {
        List<Client> GetAllClients();
        Client GetById(int clientId);
    }

    public interface IClientRepository : IClientRepository<IClient>, IEntityFrameworkRepository<IClient>
    {
    }
}
