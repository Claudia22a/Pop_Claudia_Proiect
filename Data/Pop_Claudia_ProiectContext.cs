using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pop_Claudia_Proiect.Models;

namespace Pop_Claudia_Proiect.Data
{
    public class Pop_Claudia_ProiectContext : DbContext
    {
        public Pop_Claudia_ProiectContext(DbContextOptions<Pop_Claudia_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Pop_Claudia_Proiect.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Pop_Claudia_Proiect.Models.Reservation> Reservation { get; set; } = default!;
        public DbSet<Pop_Claudia_Proiect.Models.Restaurant> Restaurant { get; set; } = default!;
        public DbSet<Pop_Claudia_Proiect.Models.Table> Table { get; set; } = default!;
        public DbSet<Menu> Menu { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Table>().HasData(
                new Table { Id = 1, Number = 1, Seats = 4, RestaurantId = 1 },
                new Table { Id = 2, Number = 2, Seats = 4, RestaurantId = 1 },
                new Table { Id = 3, Number = 3, Seats = 6, RestaurantId = 2 }
            );
        }
    }
}