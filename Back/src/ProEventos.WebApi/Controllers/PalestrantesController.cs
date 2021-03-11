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
using ProEventos.Persistence.interfaces;

namespace ProEventos.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalestrantesController: ControllerBase
    {
        private readonly IPalestranteService _palestranteService;
        public PalestrantesController(IPalestranteService palestranteService )
        {
            this._palestranteService = palestranteService;
        }  

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var palestrantes = await _palestranteService.GetAllPalestrantesAsync(false);
               if(palestrantes==null) return NotFound("Nenhum Palestrante encontrado.");
               return Ok(palestrantes);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os Palestrantes.Erro: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            try
            {
                var palestrante = await _palestranteService.GetPalestrantesByIdAsync(id, false);
            if(palestrante==null) return NotFound("Nenhum palestrante encontrado.");
            return Ok(palestrante);
            }
            catch (Exception ex)
            {
                
                throw new Exception("erro ao tentar recuperar Palestrante. Erro: " +ex.Message);
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome){
            try
            {
             var palestrantes = await _palestranteService.GetPalestrantesByNomeAsync(nome, false);
            if(palestrantes == null) return NotFound("Nenhum Palestrante com esse nome encontrado.");
            return Ok(palestrantes);   
            }
            catch (Exception ex)
            {
                
                throw new Exception("erro ao tentar recuperar Palestrante. Erro: " +ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Palestrante model){
            try
            {
                var palestrante = await _palestranteService.AddPalestrante(model);
                if (palestrante==null) return BadRequest("Erro ao adicionar o palestrante");
                return Ok(palestrante);
            }
                catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os palestrantes.Erro: {ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Palestrante model ){
            try
            {
            var palestrante = await _palestranteService.UpdatePalestrante(id,model);
            if(palestrante == null) return BadRequest("Palestrante nao encontrado");
            return Ok(palestrante);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " +ex.Message);
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            // dessa vez não usei ternario, como tinha feito no
            // delete do evento controller, porem a logica eh a mesma.
            var palestrante = await _palestranteService.DeletePalestrante(id);
            if(!palestrante) return BadRequest("Não foi possivel Deletar o Palestrante especificado.");
            return Ok("Deletado com Sucesso.");

        }
    }
}