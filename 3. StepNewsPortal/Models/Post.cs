using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepNewsPortal.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
    }
}
