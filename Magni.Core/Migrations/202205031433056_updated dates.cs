namespace Magni.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Birthday", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
