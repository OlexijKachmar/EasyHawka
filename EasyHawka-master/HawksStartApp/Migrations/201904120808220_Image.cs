namespace HawksStartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Image");
        }
    }
}
