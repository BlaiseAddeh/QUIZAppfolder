namespace OnlineExamSystem.Migrations.QuizOnline
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Points = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionType = c.String(),
                        Question1 = c.String(),
                        Points = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ExhibitId = c.Int(nullable: false),
                        Category_QuestionCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.QuestionCategories", t => t.Category_QuestionCategoryId)
                .ForeignKey("dbo.Exhibits", t => t.ExhibitId, cascadeDelete: true)
                .Index(t => t.ExhibitId)
                .Index(t => t.Category_QuestionCategoryId);
            
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        QuestionCategoryId = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.QuestionCategoryId);
            
            CreateTable(
                "dbo.Exhibits",
                c => new
                    {
                        ExhibitId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ExhibitId);
            
            CreateTable(
                "dbo.TestXQuestions",
                c => new
                    {
                        TestXQuestionId = c.Int(nullable: false, identity: true),
                        QuestionNumber = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestXQuestionId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.QuestionXDurations",
                c => new
                    {
                        QuestionXDurationId = c.Int(nullable: false, identity: true),
                        RquestTime = c.String(),
                        LeaveTime = c.String(),
                        AnsweredTime = c.String(),
                        RegistrationId = c.Int(nullable: false),
                        TestXQuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionXDurationId)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .ForeignKey("dbo.TestXQuestions", t => t.TestXQuestionId, cascadeDelete: true)
                .Index(t => t.RegistrationId)
                .Index(t => t.TestXQuestionId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        RegistrationDate = c.DateTime(nullable: false),
                        Token = c.String(),
                        TokenExpireTime = c.String(),
                        StudentId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegistrationId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: false)
                .Index(t => t.StudentId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccessLevel = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        PassHash = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DurationInMinute = c.String(),
                    })
                .PrimaryKey(t => t.TestId);
            
            CreateTable(
                "dbo.TestXPapers",
                c => new
                    {
                        TestXPaperId = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        MarkScored = c.Int(nullable: false),
                        ChoiceId = c.Int(nullable: false),
                        RegistrationId = c.Int(nullable: false),
                        TestXQuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestXPaperId)
                .ForeignKey("dbo.Choices", t => t.ChoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .ForeignKey("dbo.TestXQuestions", t => t.TestXQuestionId, cascadeDelete: false)
                .Index(t => t.ChoiceId)
                .Index(t => t.RegistrationId)
                .Index(t => t.TestXQuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionXDurations", "TestXQuestionId", "dbo.TestXQuestions");
            DropForeignKey("dbo.TestXPapers", "TestXQuestionId", "dbo.TestXQuestions");
            DropForeignKey("dbo.TestXPapers", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.TestXPapers", "ChoiceId", "dbo.Choices");
            DropForeignKey("dbo.TestXQuestions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Registrations", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Registrations", "StudentId", "dbo.Students");
            DropForeignKey("dbo.QuestionXDurations", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.TestXQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "ExhibitId", "dbo.Exhibits");
            DropForeignKey("dbo.Choices", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Category_QuestionCategoryId", "dbo.QuestionCategories");
            DropIndex("dbo.TestXPapers", new[] { "TestXQuestionId" });
            DropIndex("dbo.TestXPapers", new[] { "RegistrationId" });
            DropIndex("dbo.TestXPapers", new[] { "ChoiceId" });
            DropIndex("dbo.Registrations", new[] { "TestId" });
            DropIndex("dbo.Registrations", new[] { "StudentId" });
            DropIndex("dbo.QuestionXDurations", new[] { "TestXQuestionId" });
            DropIndex("dbo.QuestionXDurations", new[] { "RegistrationId" });
            DropIndex("dbo.TestXQuestions", new[] { "TestId" });
            DropIndex("dbo.TestXQuestions", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "Category_QuestionCategoryId" });
            DropIndex("dbo.Questions", new[] { "ExhibitId" });
            DropIndex("dbo.Choices", new[] { "QuestionId" });
            DropTable("dbo.TestXPapers");
            DropTable("dbo.Tests");
            DropTable("dbo.Students");
            DropTable("dbo.Registrations");
            DropTable("dbo.QuestionXDurations");
            DropTable("dbo.TestXQuestions");
            DropTable("dbo.Exhibits");
            DropTable("dbo.QuestionCategories");
            DropTable("dbo.Questions");
            DropTable("dbo.Choices");
        }
    }
}
