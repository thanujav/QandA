namespace QandA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linkUserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "UserProfile_UserId", c => c.Int());
            AddColumn("dbo.Answers", "UserProfile_UserId", c => c.Int());
            AddForeignKey("dbo.Questions", "UserProfile_UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Answers", "UserProfile_UserId", "dbo.UserProfile", "UserId");
            CreateIndex("dbo.Questions", "UserProfile_UserId");
            CreateIndex("dbo.Answers", "UserProfile_UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Answers", new[] { "UserProfile_UserId" });
            DropIndex("dbo.Questions", new[] { "UserProfile_UserId" });
            DropForeignKey("dbo.Answers", "UserProfile_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Questions", "UserProfile_UserId", "dbo.UserProfile");
            DropColumn("dbo.Answers", "UserProfile_UserId");
            DropColumn("dbo.Questions", "UserProfile_UserId");
            DropTable("dbo.UserProfile");
        }
    }
}
