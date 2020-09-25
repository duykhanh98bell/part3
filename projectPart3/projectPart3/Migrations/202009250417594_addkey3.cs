namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addkey3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ChiTietHoaDons", "Ma_HD");
            CreateIndex("dbo.ChiTietHoaDons", "Ma_San_Pham");
            AddForeignKey("dbo.ChiTietHoaDons", "Ma_HD", "dbo.HoaDons", "Ma_HD", cascadeDelete: true);
            AddForeignKey("dbo.ChiTietHoaDons", "Ma_San_Pham", "dbo.SanPhams", "Ma_SP", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietHoaDons", "Ma_San_Pham", "dbo.SanPhams");
            DropForeignKey("dbo.ChiTietHoaDons", "Ma_HD", "dbo.HoaDons");
            DropIndex("dbo.ChiTietHoaDons", new[] { "Ma_San_Pham" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "Ma_HD" });
        }
    }
}
