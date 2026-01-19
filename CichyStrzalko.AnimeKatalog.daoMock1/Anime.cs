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
        public int Id { get => Id; set => Id = value; }
        public string Name { get => Name; set => Name = value; }
        public int Episodes { get => Episodes; set => Episodes = value; }
        public string Premiere { get => Premiere; set => Premiere = value; }
        public Genre Genre { get => Genre; set => Genre = value; }
    }
}
