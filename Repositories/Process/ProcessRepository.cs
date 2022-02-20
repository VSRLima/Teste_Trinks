
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
    public class ProcessRepository : EntityFrameworkRepository<Process>, IProcessRepository<Process>, IProcessRepository
    {
        public ProcessRepository(ProcessContext aContext) : base(aContext) { }

        public ProcessRepository(ProcessContext aContext, DbSet<Process> entSet) : base(aContext, entSet) { }

        public dynamic GetAllProcess() 
        {
            try
            {
                return context.Process
                .Select(el => new {el.Active, el.MonetaryValue, el.ProcessNumber, el.ProcessState, el.StartDate, el.State, el.Client.Name }).ToList();
                //;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public Process GetById(int processId)
        {
            try
            {
                return context.Process.First(el => el.Id == processId);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public float SumAllActiveProcess()
        {
            try
            {
                float resultSum = 0;
                List<float> monetaryValues = context.Process.Select(el => el.MonetaryValue).ToList<float>();

                if (monetaryValues != null)
                {
                    foreach (var item in monetaryValues)
                    {
                        resultSum += item;
                    }
                }
                return resultSum;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public float SumActiveProcessByClient(int clientId)
        {
            try
            {
                float resultSum = 0;
                List<float> monetaryValues = context.Process.Where(el => el.ClientId == clientId && el.Active == true).Select(el => el.MonetaryValue).ToList();

                if (monetaryValues != null)
                {
                    foreach (var item in monetaryValues)
                    {
                        resultSum += item;
                    }
                }

                return resultSum;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public float CalcAverageProcessByClient(int clientId)
        {
            try
            {
                List<float> monetaryValue = context.Process.Where(el => el.ClientId == clientId && el.Active == true).Select(el => el.MonetaryValue).ToList();
                float average = 0;

                if(monetaryValue.Count > 0)
                {
                    float amount = SumActiveProcessByClient(clientId);

                    average = amount / monetaryValue.Count;

                    return average;
                }

                return average;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public int CountProcessByMonetaryValue (double value, int clientId) 
        {
            try
            {
                if (value != 0 || value != 0.0 || value >= 0)
                {
                    return context.Process.Where(el => el.MonetaryValue >= value && el.ClientId == clientId).Count();
                }
                
                throw new ArgumentNullException("Valor monetário digitado está nulo");
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Process GetProcessByDate (DateTime date)
        {
            try
            {
                if(date != null)
                {
                    Process processByDate = context.Process.First(el => el.StartDate == date);

                    if(processByDate != null)
                        return processByDate;

                    return null;
                }

                throw new ArgumentNullException("A data informada não preenchida corretamente");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<Process> GetProcessByStateClient (string state)
        {
            try
            {
                if (state != "" || state != null)
                {
                    List<Process> processByState = context.Process.Where(el => el.ProcessState == state && el.Client.State == state).ToList();

                    if (processByState.Count > 0)
                        return processByState;

                    return null;
                }

                throw new ArgumentNullException("Estado não informado");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public List<Process> ProcessContains (string acronym)
        {
            try
            {
                if(acronym != null || acronym != null)
                {
                    List<Process> processes = context.Process.ToList();
                    List<Process> processesByAcronym = new List<Process>();

                    foreach (Process item in processes)
                    {
                        if(item.ProcessNumber.Contains(acronym))
                            processesByAcronym.Add(item);
                    }

                    if (processesByAcronym.Count > 0)
                        return processesByAcronym;

                    return null;
                }

                throw new ArgumentNullException("Sigla passada não preenchida corretamente");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public int Count(Expression<Func<IProcess, bool>> predicate) => Count(predicate);

        public bool Exists(Expression<Func<IProcess, bool>> predicate) => Exists(predicate);

        public void Delete(IProcess entity) => Delete(entity);

        public IEnumerable<IProcess> Find(Expression<Func<IProcess, bool>> predicate, int skip = 0, int take = 0) => Find(predicate, skip, take);

        public void Insert(IProcess entity) => Insert((Process)entity);

        public void Update(IProcess entity) => Update((Process)entity);

        IProcess IEntityFrameworkRepository<IProcess>.CreateNew() => CreateNew();

    }

}
