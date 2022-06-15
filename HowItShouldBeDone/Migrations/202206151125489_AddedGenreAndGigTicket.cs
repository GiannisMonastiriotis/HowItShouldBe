namespace HowItShouldBeDone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenreAndGigTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gigtickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Price = c.Double(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                        Genre_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigtickets", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigtickets", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigtickets", new[] { "Genre_Id" });
            DropIndex("dbo.Gigtickets", new[] { "Customer_Id" });
            DropTable("dbo.Gigtickets");
            DropTable("dbo.Genres");
        }
    }
}
