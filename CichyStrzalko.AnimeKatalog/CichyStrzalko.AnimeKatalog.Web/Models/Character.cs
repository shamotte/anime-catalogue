using CichyStrzalko.AnimeKatalog.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CichyStrzalko.AnimeKatalog.Web.Models
{
    public class Character : ICharacter
    {
        [Key]
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]

        public IAnime Anime { get; set; }

        public byte[]? ImageData { get; set; }

    }
}
