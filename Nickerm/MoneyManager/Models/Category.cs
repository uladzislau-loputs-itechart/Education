using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager
{
    public class Category
    {
        //[Required]
        public int Id { get; set; }

        //[Required]
        //[Column(TypeName = "nvarchar(64) ")]
        public string Name { get; set; }

        //[Required]
        //[Column(TypeName = "int")]
        public int Type { get; set; }

        public int? ParentId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        //public virtual ICollection<Category> Categories { get; set; } 
    }

    public enum Type
    {
        Expenses = 1,
        Income = 0
    }
}
