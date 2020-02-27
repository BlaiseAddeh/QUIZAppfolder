namespace OnlineExamSystem.Migrations.QuizOnline
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tests", "DurationInMinute", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tests", "DurationInMinute", c => c.String());
        }
    }
}
