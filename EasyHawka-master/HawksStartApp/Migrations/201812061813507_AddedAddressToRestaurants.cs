namespace HawksStartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddressToRestaurants : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Address");
        }
    }
}
