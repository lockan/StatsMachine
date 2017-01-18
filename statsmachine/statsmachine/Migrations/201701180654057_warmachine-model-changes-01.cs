namespace statsmachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class warmachinemodelchanges01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WarmachineGames", "opponentFaction", c => c.Int(nullable: false));
            AlterColumn("dbo.WarmachineGames", "faction", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WarmachineGames", "faction", c => c.String(nullable: false));
            DropColumn("dbo.WarmachineGames", "opponentFaction");
        }
    }
}
