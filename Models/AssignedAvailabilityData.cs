using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Borsa_Andrei.Models
{
    public class AssignedAvailabilityData
    {
        public int AvailableTimeDateID { get; set; }
        public DateTime DateTime { get; set; }
        public bool Assigned { get; set; }
    }
}
