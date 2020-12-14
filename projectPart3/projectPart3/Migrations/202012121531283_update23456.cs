namespace projectPart3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update23456 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.khachs",
                c => new
                    {
                        id_Khach = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        PassWord = c.String(nullable: false),
                        ComfirmPassWord = c.String(),
                    })
                .PrimaryKey(t => t.id_Khach);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.khachs");
        }
    }
}
