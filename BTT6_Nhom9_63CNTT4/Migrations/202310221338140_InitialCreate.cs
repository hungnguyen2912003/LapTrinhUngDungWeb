namespace BTT6_Nhom9_63CNTT4.Migrations
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
                        Manv = c.Int(nullable: false, identity: true),
                        Hotennv = c.String(nullable: false),
                        Ngsinh = c.DateTime(nullable: false),
                        Luong = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hinhanh = c.String(nullable: false),
                        Maphong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Manv)
                .ForeignKey("dbo.Phongbans", t => t.Maphong, cascadeDelete: true)
                .Index(t => t.Maphong);
            
            CreateTable(
                "dbo.Phongbans",
                c => new
                    {
                        Maphong = c.Int(nullable: false, identity: true),
                        Tenphong = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Maphong);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nhanviens", "Maphong", "dbo.Phongbans");
            DropIndex("dbo.Nhanviens", new[] { "Maphong" });
            DropTable("dbo.Phongbans");
            DropTable("dbo.Nhanviens");
        }
    }
}
