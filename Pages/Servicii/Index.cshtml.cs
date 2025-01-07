using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonBellissima.Data;
using SalonBellissima.Models;

namespace SalonBellissima.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly SalonBellissima.Data.SalonBellissimaContext _context;

        public IndexModel(SalonBellissima.Data.SalonBellissimaContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Serviciu = await _context.Serviciu.ToListAsync();
        }
    }
}
