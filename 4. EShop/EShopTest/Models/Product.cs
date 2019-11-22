using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShopTest.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public bool ShowInCarousel { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

        public List<ProductTag> ProductTags { get; set; }
    }
}
