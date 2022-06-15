namespace HowItShouldBeDone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredPropertiesAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigtickets", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gigtickets", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigtickets", new[] { "Customer_Id" });
            DropIndex("dbo.Gigtickets", new[] { "Genre_Id" });
            AlterColumn("dbo.Gigtickets", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigtickets", "Customer_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Gigtickets", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Gigtickets", "Customer_Id");
            CreateIndex("dbo.Gigtickets", "Genre_Id");
            AddForeignKey("dbo.Gigtickets", "Customer_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Gigtickets", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigtickets", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigtickets", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigtickets", new[] { "Genre_Id" });
            DropIndex("dbo.Gigtickets", new[] { "Customer_Id" });
            AlterColumn("dbo.Gigtickets", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Gigtickets", "Customer_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Gigtickets", "Venue", c => c.String());
            CreateIndex("dbo.Gigtickets", "Genre_Id");
            CreateIndex("dbo.Gigtickets", "Customer_Id");
            AddForeignKey("dbo.Gigtickets", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Gigtickets", "Customer_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
