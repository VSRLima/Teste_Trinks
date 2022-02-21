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