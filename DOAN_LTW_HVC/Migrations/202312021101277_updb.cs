namespace DOAN_LTW_HVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GIOHANGs", "price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GIOHANGs", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
