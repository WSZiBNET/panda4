using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace panda4.Models
{
    [Table("Znizki")]
    public class ZnizkiModel
    {
        [Key]
        public int ZnizkiId { get; set; }
        public int UzytkownikId { get; set; }
        public int Znizka { get; set; }

    }
}
