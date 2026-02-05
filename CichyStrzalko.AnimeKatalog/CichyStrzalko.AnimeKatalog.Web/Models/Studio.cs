using CichyStrzalko.AnimeKatalog.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CichyStrzalko.AnimeKatalog.Web.Models
{
    public class Studio: IStudio
    {
        [Key]
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name can't be empty")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Address can't be empty")]
        public string Address { get; set; }


    }
}
