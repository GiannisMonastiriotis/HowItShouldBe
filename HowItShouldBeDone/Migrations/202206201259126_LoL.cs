namespace HowItShouldBeDone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManagingAlbumShops",
                c => new
                    {
                        ShopId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShopId, t.AlbumId })
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId)
                .Index(t => t.AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManagingAlbumShops", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.ManagingAlbumShops", "AlbumId", "dbo.Albums");
            DropIndex("dbo.ManagingAlbumShops", new[] { "AlbumId" });
            DropIndex("dbo.ManagingAlbumShops", new[] { "ShopId" });
            DropTable("dbo.ManagingAlbumShops");
        }
    }
}
