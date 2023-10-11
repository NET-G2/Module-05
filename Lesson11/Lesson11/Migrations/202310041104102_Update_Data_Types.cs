namespace Lesson11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Data_Types : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Email", c => c.String());
        }
    }
}
