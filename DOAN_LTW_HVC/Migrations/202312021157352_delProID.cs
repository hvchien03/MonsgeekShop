namespace DOAN_LTW_HVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delProID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GIOHANGs", "proID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GIOHANGs", "proID", c => c.Int(nullable: false));
        }
    }
}
