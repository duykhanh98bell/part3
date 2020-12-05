namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.chitiethoadons", "SanPham_ma_sp", c => c.Int());
            CreateIndex("dbo.chitiethoadons", "SanPham_ma_sp");
            AddForeignKey("dbo.chitiethoadons", "SanPham_ma_sp", "dbo.sanphams", "ma_sp");
            DropColumn("dbo.chitiethoadons", "gia_goc");
            DropColumn("dbo.chitiethoadons", "gia_khuyen_mai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.chitiethoadons", "gia_khuyen_mai", c => c.Int(nullable: false));
            AddColumn("dbo.chitiethoadons", "gia_goc", c => c.Int(nullable: false));
            DropForeignKey("dbo.chitiethoadons", "SanPham_ma_sp", "dbo.sanphams");
            DropIndex("dbo.chitiethoadons", new[] { "SanPham_ma_sp" });
            DropColumn("dbo.chitiethoadons", "SanPham_ma_sp");
        }
    }
}
