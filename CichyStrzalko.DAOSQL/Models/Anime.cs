using CichyStrzalko.AnimeKatalog.Core;
using CichyStrzalko.AnimeKatalog.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.DAOSQL.Models
{
    
        public class Anime : IAnime
        {
        
        
            public int Id { get; set; }
            public string Name { get; set; }
            public int Episodes { get; set; }
            public DateTime Premiere { get; set; }
            public Genre Genre { get; set; }

            
            

            public int StudioId { get; set; }
            public byte[] ImageData { get; set; }
    }
    
}
