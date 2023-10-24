namespace EZTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCustomerPlanForStreaming : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerPlans", "IsStreaming", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CustomerPlans", "MaxSimultaneousStreams", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerPlans", "IsHD", c => c.Boolean(nullable: false));
            DropColumn("dbo.CustomerPlans", "StreamingPlanID");
            DropColumn("dbo.CustomerPlans", "IsStreaming1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerPlans", "IsStreaming1", c => c.Boolean());
            AddColumn("dbo.CustomerPlans", "StreamingPlanID", c => c.Int());
            AlterColumn("dbo.CustomerPlans", "IsHD", c => c.Boolean());
            AlterColumn("dbo.CustomerPlans", "MaxSimultaneousStreams", c => c.Int());
            AlterColumn("dbo.CustomerPlans", "IsStreaming", c => c.Boolean());
        }
    }
}
