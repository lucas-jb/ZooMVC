using Zoo.Models;

namespace Zoo.Data
{
    public interface IAnimalRepository
    {
        Task<List<Animal>> GetAll();
        Task<Animal> GetById(int? id);
        Task<bool> Exists(int id);
        Task Add(Animal animal);
        Task Delete(int id);
    }
}
