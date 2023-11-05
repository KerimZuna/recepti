using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcimoMaui.Models
{
    public class Korisnici
    {
        public int Id { get; set; }
        public string Korisnicko { get; set; }
        public string Sifra { get; set; }
    }
}
