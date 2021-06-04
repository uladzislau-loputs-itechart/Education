using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager
{
    public class Transaction
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "decimal(16,3) ")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "datetime2(7) ")]
        public DateTime Date { get; set; }

        [Required]
        public int AssetId { get; set; }

        [Column(TypeName = "nvarchar ")]
        [StringLength(1024)]
        public string Comment { get; set; }

        [Required]
        public virtual Asset Asset { get; set; }

        public virtual Category Categories { get; set; }
    }
}
