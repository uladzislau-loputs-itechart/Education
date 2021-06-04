namespace MoneyManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Color", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Color");
        }
    }
}
