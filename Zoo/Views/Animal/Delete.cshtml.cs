using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zoo.Data;
using Zoo.Models;

namespace Zoo.Controllers
{
    public class DeleteModel : PageModel
    {
        private readonly Zoo.Data.ZooContext _context;

        public DeleteModel(Zoo.Data.ZooContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Animal Animal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Animal == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal.FirstOrDefaultAsync(m => m.Id == id);

            if (animal == null)
            {
                return NotFound();
            }
            else 
            {
                Animal = animal;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Animal == null)
            {
                return NotFound();
            }
            var animal = await _context.Animal.FindAsync(id);

            if (animal != null)
            {
                Animal = animal;
                _context.Animal.Remove(Animal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
