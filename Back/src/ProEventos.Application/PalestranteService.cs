using System;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.interfaces;

namespace ProEventos.Application
{
    public class PalestranteService : IPalestranteService
    {
       private readonly IPalestrantePersistence _palestratePersistence;
        private readonly IGeralPersistence _geralPersistence;

        public PalestranteService(IGeralPersistence geralPersistence, IPalestrantePersistence palestrantePersistence)
        {
            _geralPersistence = geralPersistence;
            _palestratePersistence = palestrantePersistence;
        }

        async Task<Palestrante> IPalestranteService.AddPalestrante(Palestrante model)
        {
            try
             {
                 _geralPersistence.Add<Palestrante>(model);
                 if(await _geralPersistence.SaveChangesAsync()){
                return await _palestratePersistence.GetPalestranteByIdAsync(model.Id,false);
            }
                return null;
             }
             catch (System.Exception e)
             {
                 throw new System.Exception(e.Message);
             }
        }

         async Task<Palestrante> IPalestranteService.UpdatePalestrante(int palestranteId, Palestrante model){
            try
            {
            var palestrante = await _palestratePersistence.GetPalestranteByIdAsync(palestranteId, false);
            if(palestrante == null) return null;
            model.Id = palestrante.Id;

            _geralPersistence.Update<Palestrante>(model);
            if(await _geralPersistence.SaveChangesAsync()){
                return await _palestratePersistence.GetPalestranteByIdAsync(model.Id, false);
            }
            return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
         }
         async Task<bool> IPalestranteService.DeletePalestrante(int palestranteId){
             try
             {
                 var palestrante = await _palestratePersistence.GetPalestranteByIdAsync(palestranteId, false);
                 if(palestrante == null) throw new Exception("Palestrante indicado nao encontrado");

                 _geralPersistence.Delete<Palestrante>(palestrante);
                 return await _geralPersistence.SaveChangesAsync();
                  
             }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
         

         }

        async Task<Palestrante[]> IPalestranteService.GetPalestrantesByNomeAsync(string nome, bool includeEventos =false){
          try
          {
             var palestrantes = await _palestratePersistence.GetAllPalestrantesByNomeAsync(nome, false);
             if(palestrantes == null) return null;
             return palestrantes;
          }
          catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        async Task<Palestrante[]> IPalestranteService.GetAllPalestrantesAsync(bool includeEventos = false){
            try
            {
                var palestrantes = await _palestratePersistence.GetAllPalestrantesAsync(false);
            if(palestrantes==null) return null;
            return palestrantes;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
       async Task<Palestrante> IPalestranteService.GetPalestrantesByIdAsync(int PalestranteId, bool includeEventos = false){
         try
         {
             var palestrante = await _palestratePersistence.GetPalestranteByIdAsync(PalestranteId,false);
         if(palestrante == null) return null;
         return palestrante;
         }
         catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

    }
}