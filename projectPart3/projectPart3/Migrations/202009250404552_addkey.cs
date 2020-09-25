namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addkey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.KhachHangs");
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        Ma_HD_Chi_Tiet = c.Int(nullable: false, identity: true),
                        Ma_HD = c.Int(nullable: false),
                        Ma_San_Pham = c.Int(nullable: false),
                        So_Luong = c.Int(nullable: false),
                        Gia_Goc = c.Int(nullable: false),
                        Gia_Khuyen_Mai = c.Int(nullable: false),
                        Ngay_Tao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_HD_Chi_Tiet);
            
            CreateTable(
                "dbo.DanhMucs",
                c => new
                    {
                        Ma_Danh_Muc = c.Int(nullable: false, identity: true),
                        Ten_Danh_Muc = c.String(),
                    })
                .PrimaryKey(t => t.Ma_Danh_Muc);
            
            CreateTable(
                "dbo.Gias",
                c => new
                    {
                        Ma_Gia = c.Int(nullable: false, identity: true),
                        Gia_Goc = c.Int(nullable: false),
                        Gia_Khuyen_Mai = c.Int(nullable: false),
                        Ngay_Ap_Dung = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_Gia);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        Ma_HD = c.Int(nullable: false, identity: true),
                        Ma_KH = c.Int(nullable: false),
                        Tong_Tien = c.Int(nullable: false),
                        Trang_Thai = c.Int(nullable: false),
                        Ghi_Chu = c.String(),
                        Ngay_Tao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_HD)
                .ForeignKey("dbo.KhachHangs", t => t.Ma_KH, cascadeDelete: true)
                .Index(t => t.Ma_KH);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        Ma_SP = c.Int(nullable: false, identity: true),
                        Ma_Gia = c.Int(nullable: false),
                        Ma_NCC = c.Int(nullable: false),
                        Ma_Danh_Muc = c.Int(nullable: false),
                        Trang_Thai = c.Int(nullable: false),
                        Ghi_Chu = c.String(),
                        Xuat_Xu = c.String(),
                        Mo_Ta = c.String(),
                        Hinh_Anh = c.String(),
                        Ngay_Tao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Ma_SP);
            
            AddColumn("dbo.KhachHangs", "Ma_Khach_Hang", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.KhachHangs", "Ten_Khach_Hang", c => c.String());
            AddColumn("dbo.KhachHangs", "Gioi_Tinh", c => c.Int(nullable: false));
            AddColumn("dbo.KhachHangs", "Email", c => c.String());
            AddColumn("dbo.KhachHangs", "Dien_Thoai", c => c.String());
            AddColumn("dbo.KhachHangs", "Dia_Chi", c => c.String(maxLength: 255));
            AddPrimaryKey("dbo.KhachHangs", "Ma_Khach_Hang");
            DropColumn("dbo.KhachHangs", "MaKhachHang");
            DropColumn("dbo.KhachHangs", "TenKhachHang");
            DropColumn("dbo.KhachHangs", "DiaChi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KhachHangs", "DiaChi", c => c.String());
            AddColumn("dbo.KhachHangs", "TenKhachHang", c => c.String());
            AddColumn("dbo.KhachHangs", "MaKhachHang", c => c.String(nullable: false, maxLength: 128, fixedLength: true));
            DropForeignKey("dbo.HoaDons", "Ma_KH", "dbo.KhachHangs");
            DropIndex("dbo.HoaDons", new[] { "Ma_KH" });
            DropPrimaryKey("dbo.KhachHangs");
            DropColumn("dbo.KhachHangs", "Dia_Chi");
            DropColumn("dbo.KhachHangs", "Dien_Thoai");
            DropColumn("dbo.KhachHangs", "Email");
            DropColumn("dbo.KhachHangs", "Gioi_Tinh");
            DropColumn("dbo.KhachHangs", "Ten_Khach_Hang");
            DropColumn("dbo.KhachHangs", "Ma_Khach_Hang");
            DropTable("dbo.SanPhams");
            DropTable("dbo.HoaDons");
            DropTable("dbo.Gias");
            DropTable("dbo.DanhMucs");
            DropTable("dbo.ChiTietHoaDons");
            AddPrimaryKey("dbo.KhachHangs", "MaKhachHang");
        }
    }
}
