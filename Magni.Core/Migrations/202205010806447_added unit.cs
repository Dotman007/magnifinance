namespace Magni.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedunit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Unit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Unit");
        }
    }
}
