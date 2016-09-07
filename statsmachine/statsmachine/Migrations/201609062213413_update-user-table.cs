namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateusertable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "faction");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "faction", c => c.String());
        }
    }
}
