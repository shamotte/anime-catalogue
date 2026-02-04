using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.DAOSQL.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Character> Characters { get; set; }
    }


}
