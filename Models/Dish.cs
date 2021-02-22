using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        [Required]
        public int DishID {get; set;}

        [Required]
        [Display(Name="Name of Dish")]
        public string Name {get; set;}

        [Required]
        [Display(Name="Description")]
        public string Description {get; set;}

        [Required]
        [Display(Name="Chef's Name")]
        public string Chef {get; set;}

        [Required]
        [Display(Name="# of Calories")]
        [Range(0, Double.PositiveInfinity)]
        public int Calories {get; set;}

        [Required(ErrorMessage="A number between 1 and 5 is required.")]
        [Range(1, 5)]
        public int Tastiness {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}