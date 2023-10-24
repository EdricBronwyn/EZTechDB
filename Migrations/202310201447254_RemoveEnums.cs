namespace EZTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEnums : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StreamingQualities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "CustomerPlan_CustomerPlanID", c => c.Int());
            AddColumn("dbo.Customers", "StreamingQuality_Id", c => c.Int());
            CreateIndex("dbo.Customers", "CustomerPlan_CustomerPlanID");
            CreateIndex("dbo.Customers", "StreamingQuality_Id");
            AddForeignKey("dbo.Customers", "CustomerPlan_CustomerPlanID", "dbo.CustomerPlans", "CustomerPlanID");
            AddForeignKey("dbo.Customers", "StreamingQuality_Id", "dbo.StreamingQualities", "Id");
            DropColumn("dbo.Customers", "SubscriptionType");
            DropColumn("dbo.Customers", "StreamingQuality");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "StreamingQuality", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "SubscriptionType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "StreamingQuality_Id", "dbo.StreamingQualities");
            DropForeignKey("dbo.Customers", "CustomerPlan_CustomerPlanID", "dbo.CustomerPlans");
            DropIndex("dbo.Customers", new[] { "StreamingQuality_Id" });
            DropIndex("dbo.Customers", new[] { "CustomerPlan_CustomerPlanID" });
            DropColumn("dbo.Customers", "StreamingQuality_Id");
            DropColumn("dbo.Customers", "CustomerPlan_CustomerPlanID");
            DropTable("dbo.StreamingQualities");
        }
    }
}
