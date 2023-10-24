namespace EZTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustomerPlansTable : DbMigration
    {
        public override void Up()
        {
            {
                Sql("INSERT INTO dbo.CustomerPlans (PlanName, Description, Price, IsStreaming, MaxSimultaneousStreams, IsHD, CustomerID) VALUES ('Individual Plan', '1 movie to 1 device at a time', 9.99, 0, 1, 0, 1)");
                Sql("INSERT INTO dbo.CustomerPlans (PlanName, Description, Price, IsStreaming, MaxSimultaneousStreams, IsHD, CustomerID) VALUES ('Friendly Plan', 'Two devices simultaneously', 19.99, 1, 2, 0, 1)");
                Sql("INSERT INTO dbo.CustomerPlans (PlanName, Description, Price, IsStreaming, MaxSimultaneousStreams, IsHD, CustomerID) VALUES ('Family Plan', 'Four devices simultaneously', 29.99, 1, 4, 1, 1)");
            }

        }
    }
}
