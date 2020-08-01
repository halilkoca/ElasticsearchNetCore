using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElasticNetCore.Entities
{
    public class Product
    {
        //public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public List<Product> Products { get; set; }
    }
}
