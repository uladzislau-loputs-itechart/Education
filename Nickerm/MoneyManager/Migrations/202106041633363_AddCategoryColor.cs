namespace MoneyManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryColor : DbMigration
    {
        public override void Up()
        {
            string color = "#233D4D";
             color = color.TrimStart('#');
            int defValue = int.Parse(color, System.Globalization.NumberStyles.HexNumber);
            AddColumn("dbo.Categories", "Color", c => c.Int(nullable: false, defaultValue: defValue));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Color");
        }
    }
}
