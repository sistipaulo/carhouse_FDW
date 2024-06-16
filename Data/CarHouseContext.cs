using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarHouse.Models;

namespace CarHouse.Data
{
    public class CarHouseContext : DbContext
    {
        public CarHouseContext (DbContextOptions<CarHouseContext> options)
            : base(options)
        {
        }

        public DbSet<CarHouse.Models.Car> Car { get; set; } = default!;

        public DbSet<CarHouse.Models.Client>? Client { get; set; }

        public DbSet<CarHouse.Models.Seller>? Seller { get; set; }

        public DbSet<CarHouse.Models.Invoice>? Invoice { get; set; }
    }
}
