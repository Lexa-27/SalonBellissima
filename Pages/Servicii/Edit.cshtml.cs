using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonBellissima.Data;
using SalonBellissima.Models;

namespace SalonBellissima.Pages.Servicii
{
    public class EditModel : AngajatiAsociatiPageModel
    {
        private readonly SalonBellissima.Data.SalonBellissimaContext _context;

        public EditModel(SalonBellissima.Data.SalonBellissimaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciu =  await _context.Serviciu
                .Include(b => b.AngajatiAsociati).ThenInclude(b => b.Angajat)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviciu == null)
            {
                return NotFound();
            }

            Serviciu = serviciu;

            PopulateAngajatAsociatData(_context, Serviciu);
            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID",
"DenumireCategorie");
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "NumeAngajat");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] 
selectedAngajati)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var serviciuToUpdate = await _context.Serviciu
            .Include(i => i.AngajatiAsociati)
                .ThenInclude(i => i.Angajat)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (serviciuToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Serviciu>(
            serviciuToUpdate,
            "Serviciu",
            i => i.Denumire,
            i => i.Pret, i => i.Durata))
            {
                UpdateAngajatiAsociati(_context, selectedAngajati, serviciuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateAngajatiAsociati(_context, selectedAngajati, serviciuToUpdate);
            PopulateAngajatAsociatData(_context, serviciuToUpdate);
            return Page();
        }
    }
}
