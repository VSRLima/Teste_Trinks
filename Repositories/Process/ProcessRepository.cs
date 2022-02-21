
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

        public List<ProcessWithClientName> GetAllProcess() 
        {
            try
            {
                return context.Process.Select(el => new ProcessWithClientName {
                    Id = el.Id,
                    Active = el.Active,
                    ProcessNumber = el.ProcessNumber,
                    State = el.State,
                    MonetaryValue = el.MonetaryValue,
                    StartDate = el.StartDate,
                    ClientName = el.Client.Name,
                }).ToList<ProcessWithClientName>();
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
                List<float> monetaryValues = context.Process.Where(el => el.Active == true).Select(el => el.MonetaryValue).ToList<float>();

                if (monetaryValues.Count != 0)
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

        public int Count(Expression<Func<IProcess, bool>> predicate) => Count(predicate);

        public bool Exists(Expression<Func<IProcess, bool>> predicate) => Exists(predicate);

        public void Delete(IProcess entity) => Delete(entity);

        public IEnumerable<IProcess> Find(Expression<Func<IProcess, bool>> predicate, int skip = 0, int take = 0) => Find(predicate, skip, take);

        public void Insert(IProcess entity) => Insert((Process)entity);

        public void Update(IProcess entity) => Update((Process)entity);

        IProcess IEntityFrameworkRepository<IProcess>.CreateNew() => CreateNew();

    }

}
