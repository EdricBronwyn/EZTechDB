namespace EZTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedBadModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "StreamingQuality_Id", "dbo.StreamingQualities");
            DropIndex("dbo.Customers", new[] { "StreamingQuality_Id" });
            AddColumn("dbo.CustomerPlans", "IsStreaming", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerPlans", "MaxSimultaneousStreams", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerPlans", "IsHD", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "StreamingQuality_Id");
            DropTable("dbo.StreamingQualities");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Customers", "StreamingQuality_Id", c => c.Int());
            DropColumn("dbo.CustomerPlans", "IsHD");
            DropColumn("dbo.CustomerPlans", "MaxSimultaneousStreams");
            DropColumn("dbo.CustomerPlans", "IsStreaming");
            CreateIndex("dbo.Customers", "StreamingQuality_Id");
            AddForeignKey("dbo.Customers", "StreamingQuality_Id", "dbo.StreamingQualities", "Id");
        }
    }
}
