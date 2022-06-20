namespace HowItShouldBeDone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoL1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ManagingAlbumShops", "ShopId", "dbo.Shops");
            AddForeignKey("dbo.ManagingAlbumShops", "ShopId", "dbo.Shops", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManagingAlbumShops", "ShopId", "dbo.Shops");
            AddForeignKey("dbo.ManagingAlbumShops", "ShopId", "dbo.Shops", "Id", cascadeDelete: true);
        }
    }
}
