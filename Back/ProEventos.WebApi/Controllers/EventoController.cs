using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.WebApi.Models;

namespace ProEventos.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

         public EventoController()
        {
        }

        public IEnumerable<Evento> _evento = new Evento[]{
         new Evento{
         EventoId = 1,
         Local = "Fartura SP",
         Lote = "Primeiro Lote",
         Tema = "Festa",
         QtdPessoas = 200,
         DataEvento = DateTime.Now.AddDays(2).ToString(),
         ImageUrl = "foto.png"
         },
         new Evento{
         EventoId = 2,
         Local = "Carlopolis SP",
         Lote = "Segundo Lote",
         Tema = "Cachaça",
         QtdPessoas = 220,
         DataEvento = DateTime.Now.AddDays(4).ToString(),
         ImageUrl = "OutraFoto.png"
         }
        };


        [HttpGet]
        public IEnumerable<Evento> Get()
        {
         return _evento;
             
         
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
         return _evento.Where(ev=>ev.EventoId == id);
             
         
        }

        [HttpPost]
        public string Post()
        {
         return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
         return $"Exemplo de Put {id}";
        }

        [HttpDelete("{id}")]
        public string Delete( int id)
        {
         return "Exemplo de Delete";
        }
    }
}
