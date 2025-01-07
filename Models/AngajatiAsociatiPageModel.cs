using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonBellissima.Data;
using SalonBellissima.Models;

namespace SalonBellissima.Models
{
    public class AngajatiAsociatiPageModel : PageModel
    {
        public List<AngajatAsociatData> AngajatAsociatDataList;
        public void PopulateAngajatAsociatData(SalonBellissimaContext context,
        Serviciu serviciu)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (serviciu == null) throw new ArgumentNullException(nameof(serviciu));

            var angajatiAsociati = serviciu.AngajatiAsociati
                .Select(c => c.AngajatID)
                .ToHashSet() ?? new HashSet<int>(); //
            AngajatAsociatDataList = new List<AngajatAsociatData>();
            var allEmployees = context.Angajat;

            foreach (var emp in allEmployees)
            {
                AngajatAsociatDataList.Add(new AngajatAsociatData
                {
                    AngajatID = emp.ID,
                    NumeAngajat = emp.NumeAngajat,
                    Asociat = angajatiAsociati.Contains(emp.ID)
                });
            }
        }
        public void UpdateAngajatiAsociati(SalonBellissimaContext context,
        string[] selectedAngajati, Serviciu serviciuToUpdate)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (serviciuToUpdate == null) throw new ArgumentNullException(nameof(serviciuToUpdate));

            if (selectedAngajati == null)
            {
                serviciuToUpdate.AngajatiAsociati = new List<AngajatAsociat>();
                return;
            }
            var selectedAngajatiHS = new HashSet<string>(selectedAngajati);
            var angajatiAsociati = serviciuToUpdate.AngajatiAsociati
                .Select(c => c.Angajat.ID)
                .ToHashSet() ?? new HashSet<int>();
            foreach (var emp in context.Angajat)
            {
                if (selectedAngajatiHS.Contains(emp.ID.ToString()))
                {
                    if (!angajatiAsociati.Contains(emp.ID))
                    {
                        serviciuToUpdate.AngajatiAsociati.Add(
                        new AngajatAsociat
                        {
                            ServiciuID = serviciuToUpdate.ID,
                            AngajatID = emp.ID
                        });
                    }
                }
                else
                {
                    if (angajatiAsociati.Contains(emp.ID))
                    {
                        AngajatAsociat serviciuToRemove
                        = serviciuToUpdate
                        .AngajatiAsociati
                       .SingleOrDefault(i => i.AngajatID == emp.ID);
                        context.Remove(serviciuToRemove);
                    }
                }
            }
        }
    }
}
