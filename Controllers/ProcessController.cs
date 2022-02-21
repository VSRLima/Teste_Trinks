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
    public class ProcessController : Controller
    {
        private readonly ProcessContext processContext;

        public ProcessController(ProcessContext processContext) {
            this.processContext = processContext;
        }

        [HttpGet("GetAllProcess")]
        public IActionResult GetAllProcess()
        {
            try
            {
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
                List<ProcessWithClientName> processes = processRepo.GetAllProcess(); 

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
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
                Process process = processRepo.GetById(processId); 

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
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
                float value = processRepo.SumAllActiveProcess(); 

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
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
                float value = processRepo.SumActiveProcessByClient(clientId); 

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
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
               float value = processRepo.CalcAverageProcessByClient(clientId); 

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
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
               int value = processRepo.CountProcessByMonetaryValue(clientId: request.clientId, value: request.monetaryValue); 

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
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
               Process process = processRepo.GetProcessByDate(dateTime); 

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
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
               List<Process> processes = processRepo.GetProcessByStateClient(state); 

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
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
               List<Process> processes = processRepo.ProcessContains(acronym); 

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
        public IActionResult Update([FromBody] Process process)
        {
            try
            {
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
                if(process != null)
                {
                    processRepo.Update(process); 
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
        public IActionResult Insert([FromBody] Process process)
        {
            try
            {
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
                if(process != null)
                {
                    processRepo.Insert(process); 
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
                IProcessRepository<Process> processRepo = processContext.GetProcessRepository();
                if(processId != 0)
                {
                    processRepo.DeleteById(processId); 
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