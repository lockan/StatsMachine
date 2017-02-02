namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class warmachineplayertoUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarmachineGames", "UserId", c => c.String());
            DropColumn("dbo.WarmachineGames", "player");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WarmachineGames", "player", c => c.String(nullable: false));
            DropColumn("dbo.WarmachineGames", "UserId");
        }
    }
}
