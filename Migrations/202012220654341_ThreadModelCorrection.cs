namespace InternetBasedDiscussionForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThreadModelCorrection : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Threads", name: "applicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Threads", name: "IX_applicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Threads", name: "IX_UserId", newName: "IX_applicationUser_Id");
            RenameColumn(table: "dbo.Threads", name: "UserId", newName: "applicationUser_Id");
        }
    }
}
