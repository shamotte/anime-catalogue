using CichyStrzalko.AnimeKatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.AnimeKatalog.daoMock1
{
    internal record class Studio : IStudio
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
