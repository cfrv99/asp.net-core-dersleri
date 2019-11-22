using RazorPagesGuestBook.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesGuestBook.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
