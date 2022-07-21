using Zoo.Models;

namespace Zoo.Data
{
    public interface IEspecieRepository
    {
        Task<List<Especie>> GetAll();
        Task<Especie> GetById(int? id);
        Task<bool> Exists (int id);
        Task Add(Especie especie);
        Task Delete (int id);
    }
}
