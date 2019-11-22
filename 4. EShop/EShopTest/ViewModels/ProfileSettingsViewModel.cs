using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShopTest.ViewModels
{
    public class ProfileSettingsViewModel
    {
        [Required]
        public string FullName { get; set; }

        public IFormFile PhotoUrl { get; set; }
    }
}
