using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace panda4.Models
{ 
    [Table("Uzytkownicy")]
    public class UzytkownicyModel
    {
          
       [Key]
        public int UzytkownikId { get; set; }
        public string Login { get; set; }
       // public string Haslo { get; set; }
        public string Email { get; set; }
        public bool CzyAdmin { get; set; }
        public int Wypozyczone { get; set; }



    }
}
