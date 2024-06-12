namespace DOAN_LTW_HVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class giohang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GIOHANGs",
                c => new
                    {
                        MAGH = c.Int(nullable: false, identity: true),
                        MASP = c.Int(nullable: false),
                        SL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MAGH)
                .ForeignKey("dbo.SANPHAMs", t => t.MASP, cascadeDelete: true)
                .Index(t => t.MASP);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GIOHANGs", "MASP", "dbo.SANPHAMs");
            DropIndex("dbo.GIOHANGs", new[] { "MASP" });
            DropTable("dbo.GIOHANGs");
        }
    }
}
