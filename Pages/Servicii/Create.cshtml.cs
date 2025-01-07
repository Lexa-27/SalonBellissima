using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonBellissima.Data;
using SalonBellissima.Models;

namespace SalonBellissima.Pages.Servicii
{
    public class CreateModel : AngajatiAsociatiPageModel
    {
        private readonly SalonBellissima.Data.SalonBellissimaContext _context;

        public CreateModel(SalonBellissima.Data.SalonBellissimaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "ID", "NumeAngajat");
            var serviciu = new Serviciu();
            serviciu.AngajatiAsociati = new List<AngajatAsociat>();
            PopulateAngajatAsociatData(_context, serviciu);
            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID",
"DenumireCategorie");
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } 

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedAngajati)
        {
            var newServiciu = new Serviciu();
            if (selectedAngajati != null)
            {
                newServiciu.AngajatiAsociati = new List<AngajatAsociat>();
                foreach (var cat in selectedAngajati)
                {
                    var empToAdd = new AngajatAsociat
                    {
                        AngajatID = int.Parse(cat)
                    };
                    newServiciu.AngajatiAsociati.Add(empToAdd);
                }
            }
            Serviciu.AngajatiAsociati = newServiciu.AngajatiAsociati;
            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
