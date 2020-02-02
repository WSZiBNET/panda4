using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace panda4.Models
{
    [Table("Komputer")]
    public class KomputerModel
    {
        [Key]
        public int KomputerID { get; set; }
        public string Model { get; set; }
        public string Producent { get; set; }
        public decimal Cena { get; set; }
        public DateTime DataProdukcji { get; set; }
        public string KartaGraficzna { get; set; }
        public string Procesor { get; set; }
        public string PlytaGlowna { get; set; }
        
        public virtual ICollection<OcenaModel> Oceny { get; set; }
        public double sredniaOcena;

    }
}
