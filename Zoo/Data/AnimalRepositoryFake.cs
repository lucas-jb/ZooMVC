using Zoo.Models;

namespace Zoo.Data
{
    public class AnimalRepositoryFake : IAnimalRepository
    {
        private List<Animal> listaAnimales { get; set; } = new List<Animal>();
        public AnimalRepositoryFake()
        {
            var Animal1 = new Animal()
            {
                Id = 1,
                Name = "A",
                EspecieId = 1,
                Edad = 1,
                Velocidad = 1
            };
            var Animal2 = new Animal()
            {
                Id = 1,
                Name = "A",
                EspecieId = 1,
                Edad = 1,
                Velocidad = 1
            };
            var Animal3 = new Animal()
            {
                Id = 1,
                Name = "A",
                EspecieId = 1,
                Edad = 1,
                Velocidad = 1
            };

            this.listaAnimales.Add(Animal1);
            this.listaAnimales.Add(Animal2);
            this.listaAnimales.Add(Animal3);


        }
        public async Task<List<Animal>> GetAll()
        {
            return await Task.Run(() => listaAnimales.ToList());
        }

        public async Task<Animal> GetById(int? id)
        {
            var animal = listaAnimales.FindAll(x => x.Id == id).FirstOrDefault();
            if (animal is null)
                return null;
            else
                return animal;
        }

        public async Task<bool> Exists(int id)
        {
            var animal = listaAnimales.FindAll(x => x.Id == id).FirstOrDefault();
            if (animal is null)
                return false;
            else
                return true;
        }

        public async Task Add(Animal animal)
        {
            await Task.Run(() => listaAnimales.Add(animal));
        }

        public async Task Delete(int id)
        {
            var animal = await GetById(id);
            if (animal is not null)
            {
                await Task.Run(() => listaAnimales.Remove(animal));
            }
        }
    }
}