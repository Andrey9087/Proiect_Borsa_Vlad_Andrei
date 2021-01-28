using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Borsa_Andrei.Data;

namespace Proiect_Borsa_Andrei.Models
{
    public class ClientAppointmentsPageModel : PageModel
    {
        public List<AssignedAvailabilityData> AssignedAvailabilityDataList;
        public void PopulateAssignedAvailabilityData(Proiect_Borsa_AndreiContextV3 context, Client client)
        {
            var allDates = context.AvailableTimeDate;
            var appointments = new HashSet<int>(client.Appointments.Select(c => c.ClientID));
            AssignedAvailabilityDataList = new List<AssignedAvailabilityData>();    
            foreach(var cat in allDates)
            {
                AssignedAvailabilityDataList.Add(new AssignedAvailabilityData
                {
                    AvailableTimeDateID = cat.ID,
                    DateTime = cat.Availabilty,
                    Assigned = appointments.Contains(cat.ID)
                });

            }
        }
        public void UpdateAvailableHoursAndDates(Proiect_Borsa_AndreiContextV3 context, string[] selectedDatesAndHours, Client clientToUpdate)
        {
            if(selectedDatesAndHours == null)
            {
                clientToUpdate.Appointments = new List<Appointment>();
                return;
            }
            var selectedAvailableDatesAndHoursHS = new HashSet<string>(selectedDatesAndHours);
            var appointments = new HashSet<int>(clientToUpdate.Appointments.Select(c => c.AvailableTimeDate.ID));

            foreach (var cat in context.AvailableTimeDate)
            {
                if (selectedAvailableDatesAndHoursHS.Contains(cat.ID.ToString()))
                {
                    if (!appointments.Contains(cat.ID))
                    {
                        clientToUpdate.Appointments.Add(new Appointment
                        {
                            ClientID = clientToUpdate.ID,
                            AvailableTimeDateID = cat.ID
                        }) ;

                    }
                }
                else
                {
                    if (appointments.Contains(cat.ID))
                    {
                        Appointment remove = clientToUpdate
                            .Appointments
                            .SingleOrDefault(i => i.AvailableTimeDateID == cat.ID);
                        context.Remove(remove);
                    }
                }
            }
        }
    }
}
