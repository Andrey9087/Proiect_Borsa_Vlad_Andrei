using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Borsa_Andrei.Models
{
    public class Mecanic
    {
        public int ID { get; set; }
        public string Code { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prenumele mecanicului trebuie sa contina doar litere si sa incepa cu Majuscula"), Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele Mecanicului trebuie sa contina doar litere si sa incepa cu Majuscula"), Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool Available { get; set; }
        [Required]
        public string Type { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
