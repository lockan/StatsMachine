namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_Games : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Games", newName: "SupportedGames");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SupportedGames", newName: "Games");
        }
    }
}
