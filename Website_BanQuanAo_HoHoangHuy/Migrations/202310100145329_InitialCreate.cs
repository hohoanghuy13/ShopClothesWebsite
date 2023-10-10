namespace Website_BanQuanAo_HoHoangHuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        MaCTHD = c.Int(nullable: false, identity: true),
                        MaHoaDon = c.Int(nullable: false),
                        MaSanPham = c.Int(nullable: false),
                        SoLuong = c.Int(),
                        Gia = c.Single(),
                        ThanhTien = c.Single(),
                    })
                .PrimaryKey(t => t.MaCTHD)
                .ForeignKey("dbo.HoaDons", t => t.MaHoaDon, cascadeDelete: true)
                .ForeignKey("dbo.SanPhams", t => t.MaSanPham, cascadeDelete: true)
                .Index(t => t.MaHoaDon)
                .Index(t => t.MaSanPham);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        NgayMua = c.DateTime(),
                        KhachHang = c.String(),
                        TongTien = c.Single(),
                        TrangThaiDonHang = c.String(),
                    })
                .PrimaryKey(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        MaSanPham = c.Int(nullable: false, identity: true),
                        TenSanPham = c.String(),
                        Gia = c.Single(),
                        KichThuoc = c.String(),
                        MoTa = c.String(),
                        SoLuongKho = c.Int(),
                        HinhAnh = c.String(),
                        LoaiSanPham_MaLoaiSP = c.Int(),
                    })
                .PrimaryKey(t => t.MaSanPham)
                .ForeignKey("dbo.LoaiSanPhams", t => t.LoaiSanPham_MaLoaiSP)
                .Index(t => t.LoaiSanPham_MaLoaiSP);
            
            CreateTable(
                "dbo.LoaiSanPhams",
                c => new
                    {
                        MaLoaiSP = c.Int(nullable: false, identity: true),
                        TenLoaiSP = c.String(),
                    })
                .PrimaryKey(t => t.MaLoaiSP);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietHoaDons", "MaSanPham", "dbo.SanPhams");
            DropForeignKey("dbo.SanPhams", "LoaiSanPham_MaLoaiSP", "dbo.LoaiSanPhams");
            DropForeignKey("dbo.ChiTietHoaDons", "MaHoaDon", "dbo.HoaDons");
            DropIndex("dbo.SanPhams", new[] { "LoaiSanPham_MaLoaiSP" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaSanPham" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaHoaDon" });
            DropTable("dbo.LoaiSanPhams");
            DropTable("dbo.SanPhams");
            DropTable("dbo.HoaDons");
            DropTable("dbo.ChiTietHoaDons");
        }
    }
}
