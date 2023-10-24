namespace EZTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestCustomerModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CustomerPlan_CustomerPlanID", "dbo.CustomerPlans");
            DropForeignKey("dbo.CustomerPlans", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.CustomerPlans", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Customers", new[] { "CustomerPlan_CustomerPlanID" });
            DropColumn("dbo.CustomerPlans", "CustomerID");
            RenameColumn(table: "dbo.CustomerPlans", name: "Customer_CustomerID", newName: "CustomerID");
            AlterColumn("dbo.CustomerPlans", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerPlans", "CustomerID");
            AddForeignKey("dbo.CustomerPlans", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            DropColumn("dbo.Customers", "MaxDevices");
            DropColumn("dbo.Customers", "SubscriptionPrice");
            DropColumn("dbo.Customers", "CustomerPlan_CustomerPlanID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerPlan_CustomerPlanID", c => c.Int());
            AddColumn("dbo.Customers", "SubscriptionPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Customers", "MaxDevices", c => c.Int(nullable: false));
            DropForeignKey("dbo.CustomerPlans", "CustomerID", "dbo.Customers");
            DropIndex("dbo.CustomerPlans", new[] { "CustomerID" });
            AlterColumn("dbo.CustomerPlans", "CustomerID", c => c.Int());
            RenameColumn(table: "dbo.CustomerPlans", name: "CustomerID", newName: "Customer_CustomerID");
            AddColumn("dbo.CustomerPlans", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CustomerPlan_CustomerPlanID");
            CreateIndex("dbo.CustomerPlans", "Customer_CustomerID");
            AddForeignKey("dbo.CustomerPlans", "Customer_CustomerID", "dbo.Customers", "CustomerID");
            AddForeignKey("dbo.Customers", "CustomerPlan_CustomerPlanID", "dbo.CustomerPlans", "CustomerPlanID");
        }
    }
}
