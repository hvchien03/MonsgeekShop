namespace DOAN_LTW_HVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DONHANGs",
                c => new
                    {
                        MADH = c.Int(nullable: false, identity: true),
                        MAGH = c.Int(nullable: false),
                        TIME = c.DateTime(nullable: false),
                        PHUONGTHUC = c.String(),
                        MASP = c.Int(nullable: false),
                        SL = c.Int(nullable: false),
                        Username = c.String(),
                        TINHTRANG = c.String(),
                        THANHTIEN = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MADH)
                .ForeignKey("dbo.GIOHANGs", t => t.MAGH, cascadeDelete: true)
                .Index(t => t.MAGH);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DONHANGs", "MAGH", "dbo.GIOHANGs");
            DropIndex("dbo.DONHANGs", new[] { "MAGH" });
            DropTable("dbo.DONHANGs");
        }
    }
}
