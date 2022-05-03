namespace Magni.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "Birthday", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
