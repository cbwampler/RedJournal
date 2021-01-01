namespace RedJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Food", "Calories", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Food", "Calories", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
