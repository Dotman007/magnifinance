namespace Magni.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentGradings", "Unit", c => c.Long());
            AddColumn("dbo.StudentGradings", "Point", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentGradings", "Point");
            DropColumn("dbo.StudentGradings", "Unit");
        }
    }
}
