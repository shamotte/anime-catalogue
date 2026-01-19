using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.AnimeKatalog.daoMock1
{
    internal class Anime : IAnime
    {
        public int Id{ get; set;}
        public string Name { get; set; }
        public int Episodes { get; set; }
        public string Premiere { get; set; }
        public Genre Genre { get; set; }
        public IStudio Studio { get ; set ; }
        public string ImageFile { get ; set ; }
    }
}
