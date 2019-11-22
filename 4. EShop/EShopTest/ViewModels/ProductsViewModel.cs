using EShopTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopTest.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> CarouselProducts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
