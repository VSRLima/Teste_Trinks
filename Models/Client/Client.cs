using System;
using System.Collections.Generic;

namespace Teste_Trinks.Models
{
    public partial class Client : IClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string State { get; set; }


        public virtual ICollection<Process> Process { get; set; }
    }
}