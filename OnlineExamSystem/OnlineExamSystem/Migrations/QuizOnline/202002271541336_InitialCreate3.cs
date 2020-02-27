namespace OnlineExamSystem.Migrations.QuizOnline
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "TokenExpireTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "TokenExpireTime", c => c.String());
        }
    }
}
