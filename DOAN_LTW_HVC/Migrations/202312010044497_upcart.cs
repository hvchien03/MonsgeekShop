namespace DOAN_LTW_HVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upcart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GIOHANGs", "proID", c => c.Int(nullable: false));
            AddColumn("dbo.GIOHANGs", "username", c => c.String());
            AddColumn("dbo.GIOHANGs", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GIOHANGs", "price");
            DropColumn("dbo.GIOHANGs", "username");
            DropColumn("dbo.GIOHANGs", "proID");
        }
    }
}
