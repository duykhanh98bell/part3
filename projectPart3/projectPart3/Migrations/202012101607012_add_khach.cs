namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_khach : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.khachhangs", "FirstName");
            DropColumn("dbo.khachhangs", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.khachhangs", "LastName", c => c.Int(nullable: false));
            AddColumn("dbo.khachhangs", "FirstName", c => c.String(nullable: false));
        }
    }
}
