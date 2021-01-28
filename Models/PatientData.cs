using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Borsa_Andrei.Models
{
    public class ClientData
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<AvailableTimeDate> AvailableTimeDates { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }

    }
}
