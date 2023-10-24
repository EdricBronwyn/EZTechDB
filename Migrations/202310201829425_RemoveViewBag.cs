namespace EZTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveViewBag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MaxDevices", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "SubscriptionPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SubscriptionPrice");
            DropColumn("dbo.Customers", "MaxDevices");
        }
    }
}
