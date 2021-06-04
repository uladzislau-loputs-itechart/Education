
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager
{
    public class Asset
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar ")]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
