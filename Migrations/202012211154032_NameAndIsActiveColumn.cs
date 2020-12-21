namespace InternetBasedDiscussionForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameAndIsActiveColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsActive");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
