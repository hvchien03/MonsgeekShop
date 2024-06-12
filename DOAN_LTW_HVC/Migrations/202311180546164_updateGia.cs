namespace DOAN_LTW_HVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGia : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SANPHAMs", "GIA", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SANPHAMs", "GIA", c => c.Double(nullable: false));
        }
    }
}
