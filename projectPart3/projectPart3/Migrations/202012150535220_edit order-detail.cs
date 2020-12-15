namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editorderdetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.chitiethoadons", "gia_goc", c => c.Int(nullable: false));
            AddColumn("dbo.chitiethoadons", "gia_khuyen_mai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.chitiethoadons", "gia_khuyen_mai");
            DropColumn("dbo.chitiethoadons", "gia_goc");
        }
    }
}
