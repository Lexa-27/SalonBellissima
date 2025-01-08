using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalonBellissima.Models;

namespace SalonBellissima.Data
{
    public class SalonBellissimaContext : DbContext
    {
        public SalonBellissimaContext (DbContextOptions<SalonBellissimaContext> options)
            : base(options)
        {
        }

        public DbSet<SalonBellissima.Models.Serviciu> Serviciu { get; set; } = default!;
        public DbSet<SalonBellissima.Models.Angajat> Angajat { get; set; } = default!;
        public DbSet<SalonBellissima.Models.Categorie> Categorie { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Serviciu>()
                .HasOne(s => s.Categorie)
                .WithMany(c => c.Servicii)
                .HasForeignKey(s => s.CategorieID);
        }
        public DbSet<SalonBellissima.Models.Client> Client { get; set; } = default!;
        public DbSet<SalonBellissima.Models.Programare> Programare { get; set; } = default!;
    }
}
