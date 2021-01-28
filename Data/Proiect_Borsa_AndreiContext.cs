using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Borsa_Andrei.Models;

namespace Proiect_Borsa_Andrei.Data
{
    public class Proiect_Borsa_AndreiContextV3 : DbContext
    {
        public Proiect_Borsa_AndreiContextV3 (DbContextOptions<Proiect_Borsa_AndreiContextV3> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Borsa_Andrei.Models.Client> Client { get; set; }

        public DbSet<Proiect_Borsa_Andrei.Models.Mecanic> Mecanic { get; set; }

        public DbSet<Proiect_Borsa_Andrei.Models.AvailableTimeDate> AvailableTimeDate { get; set; }
    }
}
