using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Borsa_Andrei.Data;
using Proiect_Borsa_Andrei.Models;

namespace Proiect_Borsa_Andrei.Pages.Clients
{
    public class EditModel : ClientAppointmentsPageModel
    {
        private readonly Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 _context;

        public EditModel(Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client
                .Include(b=>b.Mecanic)
                .Include(b=>b.Appointments).ThenInclude(b=>b.AvailableTimeDate)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Client == null)
            {
                return NotFound();
            }

            PopulateAssignedAvailabilityData(_context, Client);
            ViewData["MecanicID"] = new SelectList(_context.Set<Mecanic>(), "ID", "Code");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedAppointments)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clientToUpdate = await _context.Client
                .Include(i => i.Mecanic)
                .Include(i => i.Appointments)
                .ThenInclude(i => i.AvailableTimeDate)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (clientToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Client>(
                clientToUpdate,
                "Client",
                i => i.FirstName, i => i.LastName, i => i.Address, i => i.CNP, i => i.PhoneNumber,
                i => i.RCA, i => i.Mecanic))
            {
                UpdateAvailableHoursAndDates(_context, selectedAppointments, clientToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateAvailableHoursAndDates(_context, selectedAppointments, clientToUpdate);
            PopulateAssignedAvailabilityData(_context, clientToUpdate);
            return Page();

        }
    }
}
