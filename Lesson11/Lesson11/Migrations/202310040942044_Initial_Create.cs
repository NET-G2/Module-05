namespace Lesson11.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StartDate = c.DateTime(nullable: false),
                    EndDate = c.DateTime(nullable: false),
                    StudentId = c.Int(nullable: false),
                    SubjectId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);

            CreateTable(
                "dbo.Students",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Age = c.Int(nullable: false),
                    FullName = c.String(nullable: false, maxLength: 250),
                    PhoneNumber = c.String(),
                    Email = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Subjects",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 255),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    NumberOfHours = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropIndex("dbo.Enrollments", new[] { "SubjectId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
        }
    }
}
