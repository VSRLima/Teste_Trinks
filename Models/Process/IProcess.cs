using System;

namespace Teste_Trinks.Models
{
    public interface IProcess
    {
        int Id { get; set; }
        bool Active { get; set; }
        string ProcessNumber { get; set; }
        string State { get; set; }
        float MonetaryValue { get; set; }
        DateTime StartDate { get; set;}
        int ClientId { get; set; }

        Client Client { get; set;}
    }
}