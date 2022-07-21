using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo.Data
{
    public class AnimalRepositoryEF : IAnimalRepository
    {
        private readonly ZooContext _context;
        public async Task<List<Animal>> GetAll()
        {
            return await _context.Animal.ToListAsync();
        }

        public async Task<Animal> GetById(int? id)
        {
            var animal = await _context.Animal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return null;
            }

            return animal;
        }

        public async Task<bool> Exists(int id)
        {
            return (_context.Animal?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task Add(Animal animal)
        {
            _context.Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var animal = await _context.Animal.FindAsync(id);
            if (animal != null)
            {
                _context.Animal.Remove(animal);
            }
            await _context.SaveChangesAsync();
        }
    }
}
