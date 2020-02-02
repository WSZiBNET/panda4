using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace panda4.Models
{
    [Table("Ocena")]
    public class OcenaModel
    {
        [Key]
        public int OcenaID { get; set; }
        [ForeignKey("Komputer")]
        public int KomputerID { get; set; }
        public int Ocena { get; set; }

      //  public virtual ICollection<KomputerModel> KomputerID { get; set; }
    }
}
