using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Borsa_Andrei.Models
{
    public class Client
    {
        [Display(Name = "Client ID")]
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prenumele clientului trebuie sa contina doar litere si sa incepa cu Majuscula"), Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele clientului trebuie sa contina doar litere si sa incepa cu Majuscula"), Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [RegularExpression(@"^\d{13}$", ErrorMessage = "CNP-ul clientului trebuie sa contina 13 cifre "), Required, StringLength(13)]
        public string CNP { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Numarul de telefon al clientului trebuie sa contina 10 cifre "), Required,  StringLength(10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public bool RCA { get; set; }

        public int MecanicID { get; set; }
        public Mecanic Mecanic { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
