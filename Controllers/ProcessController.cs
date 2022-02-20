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
    [Route("api/process")]
    public class ProcessController : Controller, IDisposable
    {
        private readonly IProcessRepository iProcessRepo;
        private readonly ProcessContext processContext;

        [HttpGet("GetAllProcess")]
        public IActionResult GetAllProcess()
        {
            try
            {
               List<Process> processes = iProcessRepo.GetAllProcess(); 

               if(processes.Count > 0)
                    return Ok(processes); 

                return BadRequest("Não há nenhum processo registrado");

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("GetProcessById/{processId}")]
        public IActionResult GetProcessById(int processId)
        {
            try
            {
               Process process = iProcessRepo.GetById(processId); 

               if(process != null)
                    return Ok(process); 

                return BadRequest("Processo requisitado não existe");

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("SumAllActiveProcess")]
        public IActionResult SumAllActiveProcess()
        {
            try
            {
               float value = iProcessRepo.SumAllActiveProcess(); 

               if(value != 0 || value != 0.0)
                    return Ok(value); 

                return BadRequest("Não há processos ativos suficientes para fazer o cálculo");

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("SumActiveProcessByClient/{clientId}")]
        public IActionResult SumActiveProcessByClient(int clientId)
        {
            try
            {
               float value = iProcessRepo.SumActiveProcessByClient(clientId); 

               if(value != 0 || value != 0.0)
                    return Ok(value); 

                return BadRequest("Processo requisitado não existe");

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("CalcAverageProcessByClient/{clientId}")]
        public IActionResult CalcAverageProcessByClient(int clientId)
        {
            try
            {
               float value = iProcessRepo.CalcAverageProcessByClient(clientId); 

               if(value != 0 || value != 0.0)
                    return Ok(value); 

                return BadRequest("Não há processos ativos para que seja possível para o cliente requisitado");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("CountProcessByMonetaryValue")]
        public IActionResult CountProcessByMonetaryValue([FromBody] RequestProcessMoney request)
        {
            try
            {
               int value = iProcessRepo.CountProcessByMonetaryValue(clientId: request.clientId, value: request.monetaryValue); 

               if(value != 0)
                    return Ok(value); 

                return BadRequest("Processo requisitado não existe");

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("GetProcessByDate")]
        public IActionResult GetProcessByDate([FromBody] DateTime dateTime)
        {
            try
            {
               Process process = iProcessRepo.GetProcessByDate(dateTime); 

               if(process != null)
                    return Ok(process); 

                return BadRequest("Processo requisitado não existe");

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("GetProcessByStateClient")]
        public IActionResult GetProcessByStateClient([FromBody] string state)
        {
            try
            {
               List<Process> processes = iProcessRepo.GetProcessByStateClient(state); 

               if(processes != null || processes.Count > 0)
                    return Ok(processes); 

                return BadRequest("Processo requisitado não existe");

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("ProcessContains")]
        public IActionResult ProcessContains([FromBody] string acronym)
        {
            try
            {
               List<Process> processes = iProcessRepo.ProcessContains(acronym); 

               if(processes != null || processes.Count > 0)
                    return Ok(processes); 

                return BadRequest("Processo requisitado não existe");

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] IProcess process)
        {
            try
            {
                if(process != null)
                {
                    iProcessRepo.Update(process); 
                    processContext.SaveChanges();
                    return Ok();
                }

                return BadRequest("Não foi possível atualizar o processo requisitado");

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] IProcess process)
        {
            try
            {
                if(process != null)
                {
                    iProcessRepo.Insert(process); 
                    processContext.SaveChanges();
                    return Ok();
                }

                return BadRequest("Não foi possível inserir o processo");

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpDelete("Delete/{processId}")]
        public IActionResult Delete(int processId)
        {
            try
            {
                if(processId != 0)
                {
                    iProcessRepo.DeleteById(processId); 
                    processContext.SaveChanges();
                    return Ok();
                }

                return BadRequest("Não foi possível apagar o processo");

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}