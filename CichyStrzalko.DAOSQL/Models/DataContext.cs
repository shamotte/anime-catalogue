using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.DAOSQL.Models
{
    class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Catalog");
            Directory.CreateDirectory(appDataPath);
            string dbPath = Path.Combine(appDataPath, "catalog.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Anime> animes { get; set; }

        public DbSet<Studio> Studios { get; set; }

        public DbSet<Character> Characters { get; set; }
    }

}
