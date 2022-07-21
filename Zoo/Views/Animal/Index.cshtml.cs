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
    public class IndexModel : PageModel
    {
        private readonly Zoo.Data.ZooContext _context;

        public IndexModel(Zoo.Data.ZooContext context)
        {
            _context = context;
        }

        public IList<Animal> Animal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Animal != null)
            {
                Animal = await _context.Animal.ToListAsync();
            }
        }
    }
}
