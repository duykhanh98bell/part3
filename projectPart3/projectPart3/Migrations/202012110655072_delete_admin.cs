namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_admin : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.admins");
        }
        
        public override void Down()
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
            
        }
    }
}
