namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.hoadons", "ma_kh", "dbo.khachhangs");
            AddForeignKey("dbo.hoadons", "ma_kh", "dbo.khachs", "id_Khach", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.hoadons", "ma_kh", "dbo.khachs");
            AddForeignKey("dbo.hoadons", "ma_kh", "dbo.khachhangs", "ma_khach_hang", cascadeDelete: true);
        }
    }
}
