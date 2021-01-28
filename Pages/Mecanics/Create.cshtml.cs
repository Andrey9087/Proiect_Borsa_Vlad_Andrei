using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Borsa_Andrei.Data;
using Proiect_Borsa_Andrei.Models;

namespace Proiect_Borsa_Andrei.Pages.Mecanics
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 _context;

        public CreateModel(Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mecanic Mecanic { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mecanic.Add(Mecanic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
