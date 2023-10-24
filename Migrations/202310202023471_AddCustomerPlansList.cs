namespace EZTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerPlansList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
        "dbo.CustomerPlans",
        c => new
        {
            CustomerPlanID = c.Int(nullable: false, identity: true),
            PlanName = c.String(nullable: false, maxLength: 50),
            // Add other columns as needed
        })
        .PrimaryKey(t => t.CustomerPlanID);

            // Seed the database with initial records
            Sql("INSERT INTO dbo.CustomerPlans (PlanName) VALUES ('Plan 1')");
            Sql("INSERT INTO dbo.CustomerPlans (PlanName) VALUES ('Plan 2')");
            // Add more records as needed
        }

        public override void Down()
        {
        }
    }
}
