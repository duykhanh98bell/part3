namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.sanphams", "ngay_tao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.sanphams", "ngay_tao", c => c.DateTime(nullable: false));
        }
    }
}
