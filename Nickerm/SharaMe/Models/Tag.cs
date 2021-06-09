using System;
using System.Collections.Generic;
using System.Text;

namespace SharaMe.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Tag()
        {
            Posts = new List<Post>();
        }
    }
}
