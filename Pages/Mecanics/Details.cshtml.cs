﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Borsa_Andrei.Data;
using Proiect_Borsa_Andrei.Models;

namespace Proiect_Borsa_Andrei.Pages.Mecanics
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 _context;

        public DetailsModel(Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 context)
        {
            _context = context;
        }

        public Mecanic Mecanic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mecanic = await _context.Mecanic.FirstOrDefaultAsync(m => m.ID == id);

            if (Mecanic == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
