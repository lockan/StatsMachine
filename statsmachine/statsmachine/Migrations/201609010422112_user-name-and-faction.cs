namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernameandfaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "firstname", c => c.String());
            AddColumn("dbo.AspNetUsers", "lastname", c => c.String());
            AddColumn("dbo.AspNetUsers", "faction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "faction");
            DropColumn("dbo.AspNetUsers", "lastname");
            DropColumn("dbo.AspNetUsers", "firstname");
        }
    }
}
