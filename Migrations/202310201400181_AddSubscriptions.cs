namespace EZTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubscriptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SubscriptionType", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "MaxDevices", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "StreamingQuality", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "SubscriptionPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SubscriptionPrice");
            DropColumn("dbo.Customers", "StreamingQuality");
            DropColumn("dbo.Customers", "MaxDevices");
            DropColumn("dbo.Customers", "SubscriptionType");
        }
    }
}
