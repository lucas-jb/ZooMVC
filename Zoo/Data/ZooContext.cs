using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo.Data
{
    public class ZooContext : DbContext
    {
        public ZooContext (DbContextOptions<ZooContext> options)
            : base(options)
        {
        }

        public DbSet<Zoo.Models.Especie> Especie { get; set; } = default!;

        public DbSet<Zoo.Models.Animal>? Animal { get; set; }
    }
}
