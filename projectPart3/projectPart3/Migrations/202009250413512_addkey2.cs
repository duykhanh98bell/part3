namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addkey2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.NhaCungCaps");
            AlterColumn("dbo.NhaCungCaps", "MaNhaCungCap", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.NhaCungCaps", "MaNhaCungCap");
            CreateIndex("dbo.SanPhams", "Ma_Gia");
            CreateIndex("dbo.SanPhams", "Ma_NCC");
            CreateIndex("dbo.SanPhams", "Ma_Danh_Muc");
            AddForeignKey("dbo.SanPhams", "Ma_Danh_Muc", "dbo.DanhMucs", "Ma_Danh_Muc", cascadeDelete: true);
            AddForeignKey("dbo.SanPhams", "Ma_Gia", "dbo.Gias", "Ma_Gia", cascadeDelete: true);
            AddForeignKey("dbo.SanPhams", "Ma_NCC", "dbo.NhaCungCaps", "MaNhaCungCap", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "Ma_NCC", "dbo.NhaCungCaps");
            DropForeignKey("dbo.SanPhams", "Ma_Gia", "dbo.Gias");
            DropForeignKey("dbo.SanPhams", "Ma_Danh_Muc", "dbo.DanhMucs");
            DropIndex("dbo.SanPhams", new[] { "Ma_Danh_Muc" });
            DropIndex("dbo.SanPhams", new[] { "Ma_NCC" });
            DropIndex("dbo.SanPhams", new[] { "Ma_Gia" });
            DropPrimaryKey("dbo.NhaCungCaps");
            AlterColumn("dbo.NhaCungCaps", "MaNhaCungCap", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.NhaCungCaps", "MaNhaCungCap");
        }
    }
}
