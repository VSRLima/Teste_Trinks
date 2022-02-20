
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Teste_Trinks.Models;
using Teste_Trinks.DAL;

namespace Teste_Trinks.Repositories
{
    public class ClientRepository : EntityFrameworkRepository<Client>, IClientRepository<Client>, IClientRepository
    {
        public ClientRepository(ProcessContext aContext) : base(aContext) { }

        public ClientRepository(ProcessContext aContext, DbSet<Client> entSet) : base(aContext, entSet) { }

        public List<Client> GetAllClients()
        {
            try
            {
                return context.Client.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Client GetById(int clientId)
        {
            try
            {
                if(clientId != 0)
                {
                    Client clientById = context.Client.First(el => el.Id == clientId);

                    if(clientById != null)
                        return clientById;

                    return null;
                }

                throw new ArgumentNullException("O Id do cliente não foi corretamente preenchido");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public int Count(Expression<Func<IClient, bool>> predicate) => Count(predicate);

        public bool Exists(Expression<Func<IClient, bool>> predicate) => Exists(predicate);

        public void Delete(IClient entity) => Delete(entity);

        public IEnumerable<IClient> Find(Expression<Func<IClient, bool>> predicate, int skip = 0, int take = 0) => Find(predicate, skip, take);

        public void Insert(IClient entity) => Insert((Client)entity);

        public void Update(IClient entity) => Update((Client)entity);

        IClient IEntityFrameworkRepository<IClient>.CreateNew() => CreateNew();

    }

}
