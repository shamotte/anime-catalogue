using CichyStrzalko.AnimeKatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.DAOSQL.Models
{
    internal class Character : ICharacter
    {


        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public IAnime Anime { get; set; }

        public int AnimeId { get; set; }

        public String ImageFile { get; set; }
    }
}
