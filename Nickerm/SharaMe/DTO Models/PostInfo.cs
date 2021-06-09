using System;
using System.Collections.Generic;
using System.Text;
using SharaMe.Models;

namespace ShareMe.DTO_Models
{
    public class PostInfo
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public string Image { get; set; }

        public int Published { get; set; }

        public int Viewed { get; set; }

        public DateTime PublishedAt { get; set; }

        public string Content { get; set; }

        public virtual List<Tag> Tags { get; set; }

        public virtual List<Category> Categories { get; set; }
    }
}
