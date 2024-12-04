namespace BTT6_Nhom9_63CNTT4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChucvu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chucvus",
                c => new
                    {
                        MaCV = c.String(nullable: false, maxLength: 128),
                        TenCV = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaCV);
            
            AddColumn("dbo.Nhanviens", "MaCV", c => c.String(maxLength: 128));
            CreateIndex("dbo.Nhanviens", "MaCV");
            AddForeignKey("dbo.Nhanviens", "MaCV", "dbo.Chucvus", "MaCV");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Nhanviens", "MaCV", "dbo.Chucvus");
            DropIndex("dbo.Nhanviens", new[] { "MaCV" });
            DropColumn("dbo.Nhanviens", "MaCV");
            DropTable("dbo.Chucvus");
        }
    }
}
