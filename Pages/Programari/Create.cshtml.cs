using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonBellissima.Data;
using SalonBellissima.Models;

namespace SalonBellissima.Pages.Programari
{
    public class CreateModel : PageModel
    {
        private readonly SalonBellissima.Data.SalonBellissimaContext _context;

        public CreateModel(SalonBellissima.Data.SalonBellissimaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeClient");
        ViewData["ServiciuID"] = new SelectList(_context.Serviciu, "ID", "Denumire");
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
