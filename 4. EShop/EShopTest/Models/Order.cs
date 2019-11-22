using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShopTest.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public string Comment { get; set; }


        public bool IsDone { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
