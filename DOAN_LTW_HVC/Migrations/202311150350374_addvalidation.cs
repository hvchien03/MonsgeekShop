namespace DOAN_LTW_HVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvalidation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SANPHAMs", "MALOAI", "dbo.LOAISANPHAMs");
            DropForeignKey("dbo.SANPHAMs", "MATH", "dbo.THUONGHIEUx");
            DropIndex("dbo.SANPHAMs", new[] { "MATH" });
            DropIndex("dbo.SANPHAMs", new[] { "MALOAI" });
            AlterColumn("dbo.SANPHAMs", "TENSP", c => c.String(nullable: false));
            AlterColumn("dbo.SANPHAMs", "LAYOUT", c => c.String(nullable: false));
            AlterColumn("dbo.SANPHAMs", "GIA", c => c.Double(nullable: false));
            AlterColumn("dbo.SANPHAMs", "MOTA", c => c.String(nullable: false));
            AlterColumn("dbo.SANPHAMs", "MATH", c => c.Int(nullable: false));
            AlterColumn("dbo.SANPHAMs", "MALOAI", c => c.Int(nullable: false));
            CreateIndex("dbo.SANPHAMs", "MATH");
            CreateIndex("dbo.SANPHAMs", "MALOAI");
            AddForeignKey("dbo.SANPHAMs", "MALOAI", "dbo.LOAISANPHAMs", "MALOAI", cascadeDelete: true);
            AddForeignKey("dbo.SANPHAMs", "MATH", "dbo.THUONGHIEUx", "MATH", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SANPHAMs", "MATH", "dbo.THUONGHIEUx");
            DropForeignKey("dbo.SANPHAMs", "MALOAI", "dbo.LOAISANPHAMs");
            DropIndex("dbo.SANPHAMs", new[] { "MALOAI" });
            DropIndex("dbo.SANPHAMs", new[] { "MATH" });
            AlterColumn("dbo.SANPHAMs", "MALOAI", c => c.Int());
            AlterColumn("dbo.SANPHAMs", "MATH", c => c.Int());
            AlterColumn("dbo.SANPHAMs", "MOTA", c => c.String());
            AlterColumn("dbo.SANPHAMs", "GIA", c => c.Double());
            AlterColumn("dbo.SANPHAMs", "LAYOUT", c => c.String());
            AlterColumn("dbo.SANPHAMs", "TENSP", c => c.String());
            CreateIndex("dbo.SANPHAMs", "MALOAI");
            CreateIndex("dbo.SANPHAMs", "MATH");
            AddForeignKey("dbo.SANPHAMs", "MATH", "dbo.THUONGHIEUx", "MATH");
            AddForeignKey("dbo.SANPHAMs", "MALOAI", "dbo.LOAISANPHAMs", "MALOAI");
        }
    }
}
