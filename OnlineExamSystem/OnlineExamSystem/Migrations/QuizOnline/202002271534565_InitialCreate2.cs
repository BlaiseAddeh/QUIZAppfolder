namespace OnlineExamSystem.Migrations.QuizOnline
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "AccessLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "AccessLevel", c => c.String());
        }
    }
}
