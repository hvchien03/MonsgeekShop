namespace DOAN_LTW_HVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LOAISANPHAMs",
                c => new
                    {
                        MALOAI = c.Int(nullable: false, identity: true),
                        TENLOAI = c.String(),
                    })
                .PrimaryKey(t => t.MALOAI);
            
            CreateTable(
                "dbo.SANPHAMs",
                c => new
                    {
                        MASP = c.Int(nullable: false, identity: true),
                        TENSP = c.String(),
                        LAYOUT = c.String(),
                        DUONGDAN = c.String(),
                        GIA = c.Double(),
                        MOTA = c.String(),
                        MATH = c.Int(),
                        MALOAI = c.Int(),
                    })
                .PrimaryKey(t => t.MASP)
                .ForeignKey("dbo.LOAISANPHAMs", t => t.MALOAI)
                .ForeignKey("dbo.THUONGHIEUx", t => t.MATH)
                .Index(t => t.MATH)
                .Index(t => t.MALOAI);
            
            CreateTable(
                "dbo.THUONGHIEUx",
                c => new
                    {
                        MATH = c.Int(nullable: false, identity: true),
                        TENTH = c.String(),
                    })
                .PrimaryKey(t => t.MATH);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SANPHAMs", "MATH", "dbo.THUONGHIEUx");
            DropForeignKey("dbo.SANPHAMs", "MALOAI", "dbo.LOAISANPHAMs");
            DropIndex("dbo.SANPHAMs", new[] { "MALOAI" });
            DropIndex("dbo.SANPHAMs", new[] { "MATH" });
            DropTable("dbo.THUONGHIEUx");
            DropTable("dbo.SANPHAMs");
            DropTable("dbo.LOAISANPHAMs");
        }
    }
}
