using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.DAOSQL.Models
{
    
        internal class Anime : IAnime
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Episodes { get; set; }
            public string Premiere { get; set; }
            public Genre Genre { get; set; }

            [NotMapped]
            public IStudio Studio { get; set; }

            public int StudioId { get; set; }
            public string ImageFile { get; set; }
        }
    
}
