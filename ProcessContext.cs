using Teste_Trinks.Models;
using Microsoft.EntityFrameworkCore;
using Teste_Trinks.Map;
using System;
using System.Collections.Generic;
using Teste_Trinks.Repositories;
namespace Teste_Trinks.DAL
{
    public class ProcessContext : DbContext
    {
        public ProcessContext()
        {
            if (this.Database.IsSqlServer())
            {
                this.Database.SetCommandTimeout(500000);
            }
        }
        public ProcessContext(DbContextOptions<ProcessContext> options) : base(options)
        {
            if (this.Database.IsSqlServer())
            {
                this.Database.SetCommandTimeout(500000);
            }
        }
        
        public DbSet<Process> Process { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProcessMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            base.OnModelCreating(modelBuilder);
        }

        public IProcessRepository<Process> GetProcessRepository()
        {
            return new ProcessRepository(this, Process);
        }

        public IClientRepository<Client> GetClientRepository()
        {
            return new ClientRepository(this, Client);
        }
    }
}