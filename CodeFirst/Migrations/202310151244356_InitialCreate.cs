namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nhanviens",
                c => new
                    {
                        manhanvien = c.Int(nullable: false, identity: true),
                        tennhanvien = c.String(),
                        ngaysinh = c.DateTime(nullable: false),
                        luong = c.Decimal(nullable: false, precision: 18, scale: 2),
                        hinhanh = c.String(),
                        maphong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.manhanvien)
                .ForeignKey("dbo.Phongbans", t => t.maphong, cascadeDelete: true)
                .Index(t => t.maphong);
            
            CreateTable(
                "dbo.Phongbans",
                c => new
                    {
                        maphong = c.Int(nullable: false, identity: true),
                        tenphong = c.String(),
                    })
                .PrimaryKey(t => t.maphong);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nhanviens", "maphong", "dbo.Phongbans");
            DropIndex("dbo.Nhanviens", new[] { "maphong" });
            DropTable("dbo.Phongbans");
            DropTable("dbo.Nhanviens");
        }
    }
}
