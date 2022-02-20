using System;

namespace Teste_Trinks.Models
{
    public partial class Process : IProcess
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string ProcessNumber { get; set; }
        public string State { get; set; }
        public float MonetaryValue { get; set; }
        public DateTime StartDate { get; set;}
        public int ClientId { get; set; }
        public string ProcessState { get; set; }


        public virtual Client Client { get; set; }
    }
}