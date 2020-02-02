using Microsoft.EntityFrameworkCore;
using panda4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace panda4.Data
{
    public class KomputerDbContext : DbContext
    {
        public KomputerDbContext (DbContextOptions<KomputerDbContext> options) : base(options)
        {

        }


        public DbSet<KomputerModel> Komputer { get; set; }
        public DbSet<UzytkownicyModel> Uzytkownicy { get; set; }
        public DbSet<RezerwacjaModel> Rezerwacja { get; set; }
        public DbSet<OcenaModel> Ocena { get; set; }
        public DbSet<ZnizkiModel> Znizki { get; set; }
        
    }
}
