using CichyStrzalko.AnimeKatalog.Interfaces;
using CichyStrzalko.AnimeKatalog.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
namespace CichyStrzalko.AnimeKatalog.Web.Models
{
    public class Anime: IAnime
    {
        [Key]
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name can't be empty")]
        public string Name { get; set; }
        [Required]
        
        public DateTime Premiere { get; set; }
        [Required]
        public int StudioId { get ; set; }
        public byte[]? ImageData { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [IntegerValidator(MinValue = 1, MaxValue = int.MaxValue)]
        public int Episodes { get; set; }
    }
}
