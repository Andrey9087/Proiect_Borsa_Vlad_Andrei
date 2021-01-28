using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Borsa_Andrei.Data;
using Proiect_Borsa_Andrei.Models;

namespace Proiect_Borsa_Andrei.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 _context;

        public IndexModel(Proiect_Borsa_Andrei.Data.Proiect_Borsa_AndreiContextV3 context)
        {
            _context = context;
        }

        public IList<Client> Client { get; set; }
        public ClientData ClientD { get; set; }
        public int ClientID { get; set; }
        public int AvailableTimeDateID { get; set; }

        public async Task OnGetAsync(int? id, int? availableTimeDateID)
        {
            ClientD = new ClientData();
            ClientD.Clients = await _context.Client
                .Include(b => b.Mecanic)
                .Include(b => b.Appointments)
                .ThenInclude(b => b.AvailableTimeDate)
                .AsNoTracking()
                .OrderBy(b => b.FirstName)
                .ToListAsync();
            if (id != null)
            {
                ClientID = id.Value;
                Client client = ClientD.Clients
                    .Where(i => i.ID == id.Value).Single();
                ClientD.AvailableTimeDates = client.Appointments.Select(s => s.AvailableTimeDate);
            }
        }
    }
}
