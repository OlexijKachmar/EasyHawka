namespace HawksStartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCorpusesRestaurantsandCorpuseRestaurant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Corpuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantCorpuses",
                c => new
                    {
                        CorpuseId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CorpuseId, t.RestaurantId })
                .ForeignKey("dbo.Corpuses", t => t.CorpuseId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.CorpuseId)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        Specialization = c.String(nullable: false),
                        IsWifi = c.Boolean(nullable: false),
                        AreSittingPlaces = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantCorpuses", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.RestaurantCorpuses", "CorpuseId", "dbo.Corpuses");
            DropIndex("dbo.RestaurantCorpuses", new[] { "RestaurantId" });
            DropIndex("dbo.RestaurantCorpuses", new[] { "CorpuseId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.RestaurantCorpuses");
            DropTable("dbo.Corpuses");
        }
    }
}
