using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Borsa_Andrei.Data;
using Proiect_Borsa_Andrei.Models;

namespace Proiect_Borsa_Andrei.Pages.Clients
{
    public class CreateModel : ClientAppointmentsPageModel
    {
        private readonly Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 _context;

        public CreateModel(Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MecanicID"] = new SelectList(_context.Set<Mecanic>(), "ID", "Code");

            var client = new Client();
            client.Appointments = new List<Appointment>();
            PopulateAssignedAvailabilityData(_context, client);

            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedAppointments)
        {
            var newClient = new Client();
            if (selectedAppointments != null)
            {
                newClient.Appointments = new List<Appointment>();
                foreach (var cat in selectedAppointments)
                {
                    var catToAdd = new Appointment
                    {
                        AvailableTimeDateID = int.Parse(cat)
                    };
                    newClient.Appointments.Add(catToAdd);

                }
            }
            if (await TryUpdateModelAsync<Client>(
                    newClient,
                    "Client",
                     i => i.FirstName, i => i.LastName, i => i.Address, i => i.CNP, i => i.PhoneNumber,
                       i => i.RCA, i => i.MecanicID))
            {
                _context.Client.Add(newClient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedAvailabilityData(_context, newClient);
            return Page();

        }
    }
}
