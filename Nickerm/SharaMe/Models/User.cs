using System;
using System.Collections.Generic;
using System.Text;

namespace SharaMe.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }

        public string Hash { get; set; }

        public string Salt { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
