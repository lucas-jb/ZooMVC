using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zoo.Data;
using Zoo.Models;

namespace Zoo.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _repository;

        public AnimalController(IAnimalRepository repository)
        {
            _repository = repository;
        }

        // GET: Especies
        public async Task<IActionResult> Index()
        {
            var elementos = await _repository.GetAll();
            return View(elementos);
        }

        // GET: Especies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var elemento = await _repository.GetById(id);
            return elemento == null ? View("Index") : View(elemento);
        }

        // GET: Especies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Habitat,Extension")] Animal animal)
        {
            await _repository.Add(animal);
            return View("Index");
        }

        // GET: Especies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        // POST: Especies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EspecieId,Edad,Velocidad")] Animal animal)
        {
            return View();
        }

        // GET: Especies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View("Index");
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
