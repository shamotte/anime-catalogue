using CichyStrzalko.AnimeKatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.DAOSQL.Models
{
    internal class Studio : IStudio
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
