namespace EZTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRatingToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Rating", c => c.Int(nullable: false));
        }
    }
}
