using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using panda4.Models;

namespace panda4.Models
{
    public class KomputerContext : DbContext
    {
        public KomputerContext (DbContextOptions<KomputerContext> options)
            : base(options)
        {
        }

        public DbSet<KomputerModel> KomputerModel { get; set; }
        public DbSet<UzytkownicyModel> Uzytkownicy { get; set; }
        public DbSet<RezerwacjaModel> Rezerwacja { get; set; }
        public DbSet<OcenaModel> Ocena { get; set; }
        public DbSet<ZnizkiModel> Znizki { get; set; }
    }
}
