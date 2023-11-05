using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcimoMaui.Models;

namespace UcimoMaui
{
    public class AppDbContext : DbContext
    {
        public DbSet<Korisnici> Korisnici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "myapp.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
