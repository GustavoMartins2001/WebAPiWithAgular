using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Application.Interfaces;
using ProEventos.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace ProEventos.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public EventosController(IEventoService eventoService)
        {
            this._eventoService = eventoService;

        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var eventos = await _eventoService.GetAllEventosAsync(false);
               if(eventos==null) return NotFound("Nenhum evento encontrado.");
               return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os eventos.Erro: {ex.Message}");
            }


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
               var evento = await _eventoService.GetAllEventoByIdAsync(id,false);
               if(evento==null) return NotFound("Nenhum evento encontrado.");
               return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os eventos.Erro: {ex.Message}");
            }


        } 
        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
               var evento = await _eventoService.GetAllEventosByTemaAsync(tema,false);
               if(evento==null) return NotFound("Nenhum evento pro tema encontrado.");
               return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os eventos.Erro: {ex.Message}");
            }


        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        public async Task<IActionResult > Post(Evento model)
        {
             try
            {
               var evento = await _eventoService.AddEvento(model);
               if(evento==null) return BadRequest("Erro ao adicionar evento.");
               return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os eventos.Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Evento model)
        {
            try
            {
               var evento = await _eventoService.UpdateEvento(id,model);
               if(evento==null) return BadRequest("Erro ao adicionar evento.");
               return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar os eventos.Erro: {ex.Message}");
            }
        }
        // [EnableCors("AllowAllHeaders")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventoService.DeleteEvento(id)?
               Ok("Deletado") :
               BadRequest("Evento não deletado");
                   
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar os eventos.Erro: {ex.Message}");
            }
        }
    }
}
