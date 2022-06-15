namespace HowItShouldBeDone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_GenreId_ArtistId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Gigtickets", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Gigtickets", name: "IX_Genre_Id", newName: "IX_GenreId");
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShopAlbums",
                c => new
                    {
                        Shop_Id = c.Int(nullable: false),
                        Album_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Shop_Id, t.Album_ID })
                .ForeignKey("dbo.Shops", t => t.Shop_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_ID, cascadeDelete: true)
                .Index(t => t.Shop_Id)
                .Index(t => t.Album_ID);
            
            AddColumn("dbo.Gigtickets", "ArtistId", c => c.String(nullable: false));
            AlterColumn("dbo.Gigtickets", "Venue", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopAlbums", "Album_ID", "dbo.Albums");
            DropForeignKey("dbo.ShopAlbums", "Shop_Id", "dbo.Shops");
            DropIndex("dbo.ShopAlbums", new[] { "Album_ID" });
            DropIndex("dbo.ShopAlbums", new[] { "Shop_Id" });
            AlterColumn("dbo.Gigtickets", "Venue", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Gigtickets", "ArtistId");
            DropTable("dbo.ShopAlbums");
            DropTable("dbo.Shops");
            RenameIndex(table: "dbo.Gigtickets", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Gigtickets", name: "GenreId", newName: "Genre_Id");
        }
    }
}
