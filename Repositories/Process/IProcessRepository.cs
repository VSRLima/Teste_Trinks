using Teste_Trinks.Models;
using System.Collections.Generic;
using System;

namespace Teste_Trinks.Repositories
{
    public interface IProcessRepository<T> : IEntityFrameworkRepository<T> where T : IProcess
    {
        float SumAllActiveProcess();
        float SumActiveProcessByClient(int clientId);
        List<ProcessWithClientName> GetAllProcess();
        Process GetById(int processId);
        float CalcAverageProcessByClient(int clientId);
        int CountProcessByMonetaryValue (double value, int clientId);
        Process GetProcessByDate (DateTime date);
        List<Process> GetProcessByStateClient (string state);
        List<Process> ProcessContains (string acronym);
    }

    public interface IProcessRepository : IProcessRepository<IProcess>, IEntityFrameworkRepository<IProcess>
    {
    }
}
