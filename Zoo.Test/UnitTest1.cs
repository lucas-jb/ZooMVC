using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Zoo.Controllers;
using Zoo.Data;
using Zoo.Models;

namespace Zoo.Test
{
    [TestClass]
    public class EspeciesControllerTest
    {
        [TestMethod]
        public async Task DameTodos()
        {
            EspeciesController miController = new EspeciesController(new EspecieRepositoryFake());
            ViewResult? result = await miController.Index() as ViewResult;
            if (result != null)
            {
                List<Especie>? especies = result.ViewData.Model as List<Especie>;
                Assert.AreEqual(3,especies.Count);
                int sumatorio = especies.AsParallel().Sum(item => item.Extension);
                Assert.AreEqual(410, sumatorio);
            }
        }

        
        [TestMethod]
        public async Task AddEspecie()
        {
            EspeciesController miController = new EspeciesController(new EspecieRepositoryFake());
            var miEspecie = new Especie() { Id = 4, Extension = 160, Habitat = "Selva", Name = "Mono" };
            await miController.Create(miEspecie);
            ViewResult? result = await miController.Index() as ViewResult;
            List<Especie> especies = (List<Especie>)result.ViewData.Model;
            Assert.AreEqual(4, especies.Count);
            int sumatorio = especies.AsParallel().Sum(item => item.Extension);
            Assert.AreEqual(570, sumatorio);
        }
    }
}