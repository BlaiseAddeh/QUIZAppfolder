namespace OnlineExamSystem.Migrations.QuizOnline
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Category_QuestionCategoryId", "dbo.QuestionCategories");
            DropIndex("dbo.Questions", new[] { "Category_QuestionCategoryId" });
            DropColumn("dbo.Questions", "CategoryId");
            RenameColumn(table: "dbo.Questions", name: "Category_QuestionCategoryId", newName: "CategoryId");
            AlterColumn("dbo.Questions", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "CategoryId");
            AddForeignKey("dbo.Questions", "CategoryId", "dbo.QuestionCategories", "QuestionCategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "CategoryId", "dbo.QuestionCategories");
            DropIndex("dbo.Questions", new[] { "CategoryId" });
            AlterColumn("dbo.Questions", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Questions", name: "CategoryId", newName: "Category_QuestionCategoryId");
            AddColumn("dbo.Questions", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "Category_QuestionCategoryId");
            AddForeignKey("dbo.Questions", "Category_QuestionCategoryId", "dbo.QuestionCategories", "QuestionCategoryId");
        }
    }
}
