namespace InternetBasedDiscussionForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsFavouriteColInThread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Threads", "IsFavourite", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Threads", "IsFavourite");
        }
    }
}
