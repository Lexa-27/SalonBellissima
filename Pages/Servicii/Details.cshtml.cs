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
    public class DetailsModel : PageModel
    {
        private readonly SalonBellissima.Data.SalonBellissimaContext _context;

        public DetailsModel(SalonBellissima.Data.SalonBellissimaContext context)
        {
            _context = context;
        }

        public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);
            if (serviciu == null)
            {
                return NotFound();
            }
            else
            {
                Serviciu = serviciu;
            }
            return Page();
        }
    }
}
