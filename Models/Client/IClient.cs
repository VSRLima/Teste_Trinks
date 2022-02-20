using System;
using System.Collections.Generic;

namespace Teste_Trinks.Models
{
    public interface IClient
    {
        int Id { get; set; }
        string Name { get; set; }
        string CNPJ { get; set; }
        string State { get; set; }
    }
}