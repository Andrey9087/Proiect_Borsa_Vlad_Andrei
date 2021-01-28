using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Borsa_Andrei.Data;
using Proiect_Borsa_Andrei.Models;

namespace Proiect_Borsa_Andrei.Pages.AvailableTimeDates
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 _context;

        public DeleteModel(Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 context)
        {
            _context = context;
        }

        [BindProperty]
        public AvailableTimeDate AvailableTimeDate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AvailableTimeDate = await _context.AvailableTimeDate.FirstOrDefaultAsync(m => m.ID == id);

            if (AvailableTimeDate == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AvailableTimeDate = await _context.AvailableTimeDate.FindAsync(id);

            if (AvailableTimeDate != null)
            {
                _context.AvailableTimeDate.Remove(AvailableTimeDate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
