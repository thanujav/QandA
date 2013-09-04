namespace QandA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanswers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Desc = c.String(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
