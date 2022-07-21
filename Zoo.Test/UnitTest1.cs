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

            var result = (ViewResult) await miController.Index();
            Assert.IsNotNull(miController);
            Assert.IsNotNull(result);
            //var aux = result.ViewData.ToList<Especie>();
            
            Assert.AreEqual(3,result.ViewData.Model);
        }
        [TestMethod]
        public async Task AddEspecie()
        {
            EspeciesController miController = new EspeciesController(new EspecieRepositoryFake());
            var miEspecie = new Especie() { Id = 4, Extension = 160, Habitat = "Selva", Name = "Mono" };
            await miController.Create(miEspecie);
            var result = (ViewResult)await miController.Index();
            Assert.IsNotNull(miController);
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.ViewData.Count);
        }
    }
}