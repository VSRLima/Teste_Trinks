using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Trinks.Models;
using Teste_Trinks.Repositories;
using Teste_Trinks.DAL;

namespace Teste_Trinks.Controllers
{
    [Produces("application/json")]
    [Route("api/client")]
    public class ClientController : Controller
    {
        private readonly ProcessContext processContext;

        public ClientController(ProcessContext processContext) {
            this.processContext = processContext;
        }

        [HttpGet("GetAllClient")]
        public IActionResult GetAllClient()
        {
            try
            {
                IClientRepository<Client> clientRepo = processContext.GetClientRepository();
                List<Client> clients = clientRepo.GetAllClients(); 

                if(clients.Count > 0)
                    return Ok(clients); 

                return BadRequest("Não há nenhum cliente registrado");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("GetById/{clientId}")]
        public IActionResult GetById(int clientId)
        {
            try
            {
                IClientRepository<Client> clientRepo = processContext.GetClientRepository();
                Client clients = clientRepo.GetById(clientId); 

                if(clients != null)
                    return Ok(clients); 

                return BadRequest("Não há nenhum cliente registrado");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("Insert")]
        public IActionResult Insert(Client client)
        {
            try
            {
                if(client != null) {
                    IClientRepository<Client> clientRepo = processContext.GetClientRepository();
                    clientRepo.Insert(client); 
                    processContext.SaveChanges();
                    return Ok(); 
                }
            
                return BadRequest("Não foi possível inserir o cliente");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("Update")]
        public IActionResult Update(Client client)
        {
            try
            {
                if(client != null) {
                    IClientRepository<Client> clientRepo = processContext.GetClientRepository();
                    clientRepo.Update(client); 
                    processContext.SaveChanges();
                    return Ok(); 
                }
            
                return BadRequest("Não foi possível atualizar o cliente");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpDelete("Delete/{clientId}")]
        public IActionResult Delete(int clientId)
        {
            try
            {
                if(clientId != 0) {
                    IClientRepository<Client> clientRepo = processContext.GetClientRepository();
                    clientRepo.DeleteById(clientId); 
                    processContext.SaveChanges();
                    return Ok(); 
                }
            
                return BadRequest("Não foi possível atualizar o cliente");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}