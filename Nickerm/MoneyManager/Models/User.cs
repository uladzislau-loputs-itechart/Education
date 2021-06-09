using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoneyManager
{
    public class User
    {
        //[Required]
        public int Id { get; set; }

        //[Required]
        //[Column(TypeName = "nvarchar(64) ")]
        public string Name { get; set; }

        //[Required]
        //[Column(TypeName = "nvarchar(64) ")]
        public string Email { get; set; }

        //[Required]
        //[Column(TypeName = "nvarchar(1024) ")]
        public string Hash { get; set; }

        //[Required]
        //[Column(TypeName = "nvarchar(1024) ")]
        public string Salt { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
