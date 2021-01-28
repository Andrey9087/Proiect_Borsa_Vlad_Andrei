using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Borsa_Andrei.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public int AvailableTimeDateID { get; set; }
        public AvailableTimeDate AvailableTimeDate { get; set; }
    }
}
