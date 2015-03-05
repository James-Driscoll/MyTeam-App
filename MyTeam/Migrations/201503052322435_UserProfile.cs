namespace MyTeam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ContactNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressLine1", c => c.String());
            AddColumn("dbo.AspNetUsers", "AddressLine2", c => c.String());
            AddColumn("dbo.AspNetUsers", "Town", c => c.String());
            AddColumn("dbo.AspNetUsers", "County", c => c.String());
            AddColumn("dbo.AspNetUsers", "Postcode", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "Postcode");
            DropColumn("dbo.AspNetUsers", "County");
            DropColumn("dbo.AspNetUsers", "Town");
            DropColumn("dbo.AspNetUsers", "AddressLine2");
            DropColumn("dbo.AspNetUsers", "AddressLine1");
            DropColumn("dbo.AspNetUsers", "ContactNumber");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
