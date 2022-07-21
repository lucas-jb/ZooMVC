using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Zoo.Models;

namespace Zoo.Data
{
    public class EspecieRepositoryFake : IEspecieRepository
    {
        private List<Especie> listaEspecies { get; set; } = new List<Especie>();
        public EspecieRepositoryFake()
        {
            var Especie1 = new Especie() 
            { 
                Id = 1, Extension = 100, Habitat = "Sabana", 
                Name = "Cebra"
            };
            var Especie2 = new Especie()
            {
                Id = 2, Extension = 150, Habitat = "Sabana",
                Name = "Leon"
            };
            var Especie3 = new Especie()
            {
                Id = 3, Extension = 160, Habitat = "Desierto",
                Name = "Cobra del desierto"
            };

            this.listaEspecies.Add(Especie1);
            this.listaEspecies.Add(Especie2);
            this.listaEspecies.Add(Especie3);


        }
        public async Task<List<Especie>> GetAll()
        {
            return await Task.Run(()=>listaEspecies.ToList()); 
        }

        public async Task<Especie> GetById(int? id)
        {
            var especie = listaEspecies.FindAll(x=>x.Id == id).FirstOrDefault();
            if (especie is null)
                return null;
            else
                return especie;
        }

        public async Task<bool> Exists(int id)
        {
            var especie = listaEspecies.FindAll(x => x.Id == id).FirstOrDefault();
            if (especie is null)
                return false;
            else
                return true;
        }

        public async Task Add(Especie especie)
        {
           await Task.Run(()=>listaEspecies.Add(especie));
        }

        public async Task Delete(int id)
        {
            var especie = await GetById(id);
            if (especie is not null)
            {
                await Task.Run(()=>listaEspecies.Remove(especie));
            }
        }
    }
}
