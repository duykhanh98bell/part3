namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admins",
                c => new
                    {
                        ma_admin = c.Int(nullable: false, identity: true),
                        tai_khoan = c.String(),
                        mat_khau = c.String(),
                    })
                .PrimaryKey(t => t.ma_admin);
            
            CreateTable(
                "dbo.chitiethoadons",
                c => new
                    {
                        ma_hd_chi_tiet = c.Int(nullable: false, identity: true),
                        ma_hd = c.Int(nullable: false),
                        ma_san_pham = c.Int(nullable: false),
                        so_luong = c.Int(nullable: false),
                        gia_goc = c.Int(nullable: false),
                        gia_khuyen_mai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ma_hd_chi_tiet)
                .ForeignKey("dbo.hoadons", t => t.ma_hd, cascadeDelete: true)
                .ForeignKey("dbo.sanphams", t => t.ma_san_pham, cascadeDelete: true)
                .Index(t => t.ma_hd)
                .Index(t => t.ma_san_pham);
            
            CreateTable(
                "dbo.hoadons",
                c => new
                    {
                        ma_hd = c.Int(nullable: false, identity: true),
                        ma_kh = c.Int(nullable: false),
                        tong_tien = c.Int(nullable: false),
                        trang_thai = c.Int(nullable: false),
                        ghi_chu = c.String(),
                        ngay_tao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ma_hd)
                .ForeignKey("dbo.khachhangs", t => t.ma_kh, cascadeDelete: true)
                .Index(t => t.ma_kh);
            
            CreateTable(
                "dbo.khachhangs",
                c => new
                    {
                        ma_khach_hang = c.Int(nullable: false, identity: true),
                        ten_khach_hang = c.String(),
                        gioi_tinh = c.Int(nullable: false),
                        email = c.String(),
                        password = c.String(),
                        dien_thoai = c.String(),
                        dia_chi = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ma_khach_hang);
            
            CreateTable(
                "dbo.sanphams",
                c => new
                    {
                        ma_sp = c.Int(nullable: false, identity: true),
                        ten_sp = c.String(),
                        ma_gia = c.Int(nullable: false),
                        ma_ncc = c.Int(nullable: false),
                        ma_danh_muc = c.Int(nullable: false),
                        trang_thai = c.Boolean(nullable: false),
                        ghi_chu = c.String(),
                        xuat_xu = c.String(),
                        mo_ta = c.String(),
                        hinh_anh = c.String(),
                    })
                .PrimaryKey(t => t.ma_sp)
                .ForeignKey("dbo.danhmucs", t => t.ma_danh_muc, cascadeDelete: true)
                .ForeignKey("dbo.gias", t => t.ma_gia, cascadeDelete: true)
                .ForeignKey("dbo.nhacungcaps", t => t.ma_ncc, cascadeDelete: true)
                .Index(t => t.ma_gia)
                .Index(t => t.ma_ncc)
                .Index(t => t.ma_danh_muc);
            
            CreateTable(
                "dbo.danhmucs",
                c => new
                    {
                        ma_danh_muc = c.Int(nullable: false, identity: true),
                        ten_danh_muc = c.String(),
                    })
                .PrimaryKey(t => t.ma_danh_muc);
            
            CreateTable(
                "dbo.gias",
                c => new
                    {
                        ma_gia = c.Int(nullable: false, identity: true),
                        gia_goc = c.Int(nullable: false),
                        gia_khuyen_mai = c.Int(nullable: false),
                        ngay_ap_dung = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ma_gia);
            
            CreateTable(
                "dbo.nhacungcaps",
                c => new
                    {
                        ma_nha_cung_cap = c.Int(nullable: false, identity: true),
                        ten_nha_cung_cap = c.String(),
                        dia_chi = c.String(),
                    })
                .PrimaryKey(t => t.ma_nha_cung_cap);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.chitiethoadons", "ma_san_pham", "dbo.sanphams");
            DropForeignKey("dbo.sanphams", "ma_ncc", "dbo.nhacungcaps");
            DropForeignKey("dbo.sanphams", "ma_gia", "dbo.gias");
            DropForeignKey("dbo.sanphams", "ma_danh_muc", "dbo.danhmucs");
            DropForeignKey("dbo.chitiethoadons", "ma_hd", "dbo.hoadons");
            DropForeignKey("dbo.hoadons", "ma_kh", "dbo.khachhangs");
            DropIndex("dbo.sanphams", new[] { "ma_danh_muc" });
            DropIndex("dbo.sanphams", new[] { "ma_ncc" });
            DropIndex("dbo.sanphams", new[] { "ma_gia" });
            DropIndex("dbo.hoadons", new[] { "ma_kh" });
            DropIndex("dbo.chitiethoadons", new[] { "ma_san_pham" });
            DropIndex("dbo.chitiethoadons", new[] { "ma_hd" });
            DropTable("dbo.nhacungcaps");
            DropTable("dbo.gias");
            DropTable("dbo.danhmucs");
            DropTable("dbo.sanphams");
            DropTable("dbo.khachhangs");
            DropTable("dbo.hoadons");
            DropTable("dbo.chitiethoadons");
            DropTable("dbo.admins");
        }
    }
}
