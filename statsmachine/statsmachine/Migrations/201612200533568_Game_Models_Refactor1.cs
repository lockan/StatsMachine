namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Game_Models_Refactor1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserGames");
            AlterColumn("dbo.UserGames", "gameid", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserGames", new[] { "userid", "gameid" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserGames");
            AlterColumn("dbo.UserGames", "gameid", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserGames", new[] { "userid", "gameid" });
        }
    }
}
