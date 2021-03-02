using System;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.interfaces;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersistence _eventoPersistence;
        private readonly IGeralPersistence _geralPersistence;
        public EventoService(IEventoPersistence eventoPersistence, IGeralPersistence geralPersistence)
        {
            _eventoPersistence = eventoPersistence;
            _geralPersistence = geralPersistence;
        }
         
        public async Task<Evento> AddEvento(Evento model)
        {
        try
        {
            _geralPersistence.Add<Evento>(model);
            if(await _geralPersistence.SaveChangesAsync()){
                return await _eventoPersistence.GetAllEventoByIdAsync(model.Id,false);
            }
            return null;
        }
        catch (Exception e)
        {
           throw new Exception(e.Message);
        }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId , false);
                if (evento == null) return null;

                model.Id = evento.Id;

               _geralPersistence.Update<Evento>(model);
               if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetAllEventoByIdAsync(model.Id,false);
                }
            return null;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           

        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
             try
            {
                var evento = await _eventoPersistence.GetAllEventoByIdAsync(eventoId , false);
                if (evento == null) throw new Exception("Evento para delete nao encontrado!");

               _geralPersistence.Delete<Evento>(evento);
               return await _geralPersistence.SaveChangesAsync();
            }   
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes)
        {
             try
            {
                var eventos = await _eventoPersistence.GetAllEventoByIdAsync(eventoId,includePalestrantes );
                if(eventos == null) return null;
                return eventos;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosAsync(false);
                if(eventos == null) return null;
                return eventos;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
             try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema,false);
                if(eventos == null) return null;
                return eventos;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

  
    }
}