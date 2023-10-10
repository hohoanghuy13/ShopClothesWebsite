namespace Website_BanQuanAo_HoHoangHuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMaLoaiSanPham : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanPhams", "LoaiSanPham_MaLoaiSP", "dbo.LoaiSanPhams");
            DropIndex("dbo.SanPhams", new[] { "LoaiSanPham_MaLoaiSP" });
            RenameColumn(table: "dbo.SanPhams", name: "LoaiSanPham_MaLoaiSP", newName: "MaLoaiSP");
            AlterColumn("dbo.SanPhams", "MaLoaiSP", c => c.Int(nullable: false));
            CreateIndex("dbo.SanPhams", "MaLoaiSP");
            AddForeignKey("dbo.SanPhams", "MaLoaiSP", "dbo.LoaiSanPhams", "MaLoaiSP", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "MaLoaiSP", "dbo.LoaiSanPhams");
            DropIndex("dbo.SanPhams", new[] { "MaLoaiSP" });
            AlterColumn("dbo.SanPhams", "MaLoaiSP", c => c.Int());
            RenameColumn(table: "dbo.SanPhams", name: "MaLoaiSP", newName: "LoaiSanPham_MaLoaiSP");
            CreateIndex("dbo.SanPhams", "LoaiSanPham_MaLoaiSP");
            AddForeignKey("dbo.SanPhams", "LoaiSanPham_MaLoaiSP", "dbo.LoaiSanPhams", "MaLoaiSP");
        }
    }
}
