namespace EZTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCustomerPlan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RentedDVDs", "DVDPlanID", "dbo.DVDPlans");
            DropIndex("dbo.RentedDVDs", new[] { "DVDPlanID" });
            AddColumn("dbo.CustomerPlans", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerPlans", "DVDPlanID", c => c.Int());
            AddColumn("dbo.CustomerPlans", "MaxDVDs", c => c.Int());
            AddColumn("dbo.CustomerPlans", "StreamingPlanID", c => c.Int());
            AddColumn("dbo.CustomerPlans", "IsStreaming1", c => c.Boolean());
            AddColumn("dbo.CustomerPlans", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.CustomerPlans", "Customer_CustomerID", c => c.Int());
            AddColumn("dbo.RentedDVDs", "DVDPlan_CustomerPlanID", c => c.Int());
            AlterColumn("dbo.CustomerPlans", "IsStreaming", c => c.Boolean());
            AlterColumn("dbo.CustomerPlans", "MaxSimultaneousStreams", c => c.Int());
            AlterColumn("dbo.CustomerPlans", "IsHD", c => c.Boolean());
            CreateIndex("dbo.CustomerPlans", "Customer_CustomerID");
            CreateIndex("dbo.RentedDVDs", "DVDPlan_CustomerPlanID");
            AddForeignKey("dbo.CustomerPlans", "Customer_CustomerID", "dbo.Customers", "CustomerID");
            AddForeignKey("dbo.RentedDVDs", "DVDPlan_CustomerPlanID", "dbo.CustomerPlans", "CustomerPlanID");
            DropTable("dbo.DVDPlans");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DVDPlans",
                c => new
                    {
                        DVDPlanID = c.Int(nullable: false, identity: true),
                        PlanName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxDVDs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DVDPlanID);
            
            DropForeignKey("dbo.RentedDVDs", "DVDPlan_CustomerPlanID", "dbo.CustomerPlans");
            DropForeignKey("dbo.CustomerPlans", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.RentedDVDs", new[] { "DVDPlan_CustomerPlanID" });
            DropIndex("dbo.CustomerPlans", new[] { "Customer_CustomerID" });
            AlterColumn("dbo.CustomerPlans", "IsHD", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CustomerPlans", "MaxSimultaneousStreams", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerPlans", "IsStreaming", c => c.Boolean(nullable: false));
            DropColumn("dbo.RentedDVDs", "DVDPlan_CustomerPlanID");
            DropColumn("dbo.CustomerPlans", "Customer_CustomerID");
            DropColumn("dbo.CustomerPlans", "Discriminator");
            DropColumn("dbo.CustomerPlans", "IsStreaming1");
            DropColumn("dbo.CustomerPlans", "StreamingPlanID");
            DropColumn("dbo.CustomerPlans", "MaxDVDs");
            DropColumn("dbo.CustomerPlans", "DVDPlanID");
            DropColumn("dbo.CustomerPlans", "CustomerID");
            CreateIndex("dbo.RentedDVDs", "DVDPlanID");
            AddForeignKey("dbo.RentedDVDs", "DVDPlanID", "dbo.DVDPlans", "DVDPlanID", cascadeDelete: true);
        }
    }
}
