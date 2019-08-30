using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace JuniorDotNet.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}
