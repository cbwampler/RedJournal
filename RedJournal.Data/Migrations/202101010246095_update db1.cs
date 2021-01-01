namespace RedJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meal", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Meal", "MoodBefore", c => c.String());
            AddColumn("dbo.Meal", "MoodAfter", c => c.String());
            AddColumn("dbo.Meal", "HungerBefore", c => c.String());
            AddColumn("dbo.Meal", "HungerAfter", c => c.String());
            AddColumn("dbo.Meal", "Location", c => c.String());
            AddColumn("dbo.Meal", "WhoWith", c => c.String());
            AddColumn("dbo.Meal", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meal", "Notes");
            DropColumn("dbo.Meal", "WhoWith");
            DropColumn("dbo.Meal", "Location");
            DropColumn("dbo.Meal", "HungerAfter");
            DropColumn("dbo.Meal", "HungerBefore");
            DropColumn("dbo.Meal", "MoodAfter");
            DropColumn("dbo.Meal", "MoodBefore");
            DropColumn("dbo.Meal", "OwnerId");
        }
    }
}
