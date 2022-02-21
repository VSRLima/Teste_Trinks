using Teste_Trinks.Models;
using System.Collections.Generic;
using System;

namespace Teste_Trinks.Repositories
{
    public interface IProcessRepository<T> : IEntityFrameworkRepository<T> where T : IProcess
    {
        float SumAllActiveProcess();
        List<ProcessWithClientName> GetAllProcess();
        Process GetById(int processId);
    }

    public interface IProcessRepository : IProcessRepository<IProcess>, IEntityFrameworkRepository<IProcess>
    {
    }
}
