namespace BTT6_Nhom9_63CNTT4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nhanviens", "Hinhanh", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nhanviens", "Hinhanh", c => c.String(nullable: false));
        }
    }
}
