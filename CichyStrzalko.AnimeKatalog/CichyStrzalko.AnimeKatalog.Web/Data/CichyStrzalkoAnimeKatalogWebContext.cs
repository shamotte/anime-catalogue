using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CichyStrzalko.AnimeKatalog.Web.Models;

namespace CichyStrzalko.AnimeKatalog.Web.Data
{
    public class CichyStrzalkoAnimeKatalogWebContext : DbContext
    {
        public CichyStrzalkoAnimeKatalogWebContext (DbContextOptions<CichyStrzalkoAnimeKatalogWebContext> options)
            : base(options)
        {
        }

        public DbSet<CichyStrzalko.AnimeKatalog.Web.Models.Studio> Studio { get; set; } = default!;
        public DbSet<CichyStrzalko.AnimeKatalog.Web.Models.Character> Character { get; set; } = default!;
        public DbSet<CichyStrzalko.AnimeKatalog.Web.Models.Anime> Anime { get; set; } = default!;
    }
}
