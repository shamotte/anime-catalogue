using CichyStrzalko.AnimeKatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.AnimeKatalog.daoMock1
{
    internal record class Character : ICharacter
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimeId { get; set; }

        public byte[] ImageData { get; set; }
    }
}
