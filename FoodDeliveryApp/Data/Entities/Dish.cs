﻿using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.Dish;
namespace FoodDeliveryApp.Data.Entities
{
    public class Dish
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string DishImage { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Descriprion { get; set; } = null!;

        //public int MenuId { get; set; }
        //public Menu Menu { get; set; }
    }
}
