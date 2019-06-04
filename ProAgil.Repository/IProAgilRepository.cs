using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

         //Eventos
         Task<Evento[]> GetAllEventosAsyncByTema(string Tema, bool includePalestrantes = false);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
         Task<Evento> GetEventosAsyncById(int EventoId, bool includePalestrantes = false);

         //Palestrantes
         Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos = false);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
         Task<Palestrante> GetPalestranteAsyncById(int PalestranteId, bool includeEventos = false);
    }
}