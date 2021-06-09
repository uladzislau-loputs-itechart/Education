using System;
using System.Collections.Generic;
using System.Text;

namespace SharaMe.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public int Published { get; set; }

        public int Viewed { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime PublishedAt { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public Post()
        {
            Tags = new List<Tag>();
            Categories = new List<Category>();
        }
    }
}
