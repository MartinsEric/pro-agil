using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;
        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            return await (_context.SaveChangesAsync()) > 0;
        }
        
        public async Task<Evento> GetEventosAsyncById(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);
            
            if(includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(x => x.Date)
                .Where(c => c.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);
            
            if(includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.Date);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosAsyncByTema(string Tema, bool includePalestrantes)
        {
           IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);
            
            if(includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(x => x.Date)
                .Where(c => c.Tema.ToLower().Contains(Tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteAsyncById(int PalestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if(includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.EventoId);
            }

            query = query.OrderBy(c => c.Nome)
                .Where(c => c.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }
        
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if(includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.EventoId);
            }

            query = query.OrderBy(c => c.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if(includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.EventoId);
            }

            query = query.OrderBy(c => c.Nome)
                .Where(c => c.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}