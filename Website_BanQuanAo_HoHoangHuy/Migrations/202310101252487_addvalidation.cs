namespace Website_BanQuanAo_HoHoangHuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SanPhams", "TenSanPham", c => c.String(nullable: false));
            AlterColumn("dbo.SanPhams", "Gia", c => c.Single(nullable: false));
            AlterColumn("dbo.SanPhams", "KichThuoc", c => c.String(nullable: false));
            AlterColumn("dbo.SanPhams", "SoLuongKho", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SanPhams", "SoLuongKho", c => c.Int());
            AlterColumn("dbo.SanPhams", "KichThuoc", c => c.String());
            AlterColumn("dbo.SanPhams", "Gia", c => c.Single());
            AlterColumn("dbo.SanPhams", "TenSanPham", c => c.String());
        }
    }
}
