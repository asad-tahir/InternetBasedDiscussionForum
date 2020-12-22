namespace InternetBasedDiscussionForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThreadModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        applicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.applicationUser_Id)
                .Index(t => t.applicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Threads", "applicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Threads", new[] { "applicationUser_Id" });
            DropTable("dbo.Threads");
        }
    }
}
