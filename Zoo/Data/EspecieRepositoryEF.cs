using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo.Data
{
    public class EspecieRepositoryEF : IEspecieRepository
    {
        private readonly ZooContext _context;
        public async Task<List<Especie>> GetAll()
        {
            return await _context.Especie.ToListAsync();
        }

        public async Task<Especie> GetById(int? id)
        {
            var especie = await _context.Especie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especie == null)
            {
                return null;
            }

            return especie;
        }

        public async Task<bool> Exists(int id)
        {
            return (_context.Especie?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task Add(Especie especie)
        {
            _context.Add(especie);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var especie = await _context.Especie.FindAsync(id);
            if (especie != null)
            {
                _context.Especie.Remove(especie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
