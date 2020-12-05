namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.chitiethoadons", "SanPham_ma_sp", "dbo.sanphams");
            DropIndex("dbo.chitiethoadons", new[] { "SanPham_ma_sp" });
            DropColumn("dbo.chitiethoadons", "SanPham_ma_sp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.chitiethoadons", "SanPham_ma_sp", c => c.Int());
            CreateIndex("dbo.chitiethoadons", "SanPham_ma_sp");
            AddForeignKey("dbo.chitiethoadons", "SanPham_ma_sp", "dbo.sanphams", "ma_sp");
        }
    }
}
