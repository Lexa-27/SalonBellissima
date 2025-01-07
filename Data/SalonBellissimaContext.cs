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
    }
}
