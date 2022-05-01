namespace Magni.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedunit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "Unit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "Unit");
        }
    }
}
